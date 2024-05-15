package CodeRunner

import (
	"bytes"
	"context"
	"errors"
	"github.com/google/uuid"
	res "github.com/moroshma/REST-ful-code-battle-platform/checkSolution/internal/lib/api/response"
	"os"
	"os/exec"
	"time"
)

type BashCodeRunner struct {
	res.Response
}

func (cr BashCodeRunner) Run(code string, test []string, checkRes []string) res.Response {
	id := uuid.New().String()
	path := "./solution/" + id

	// Создание директории
	err := os.MkdirAll(path, 0755)

	if err != nil {
		return res.Response{
			SendUUID: id,
			Status:   "Не удалось создать директорию",
			Error:    res.SystemError,
		}
	}

	// Проверка успешного создания директории
	_, dirErr := os.Stat(path)
	if dirErr != nil {
		return res.Response{
			SendUUID: id,
			Status:   "Ошибка при проверке создания директории",
			Error:    res.SystemError,
		}
	}
	defer os.RemoveAll(path)
	// Создание файла
	codePath := path + "/app.go"
	file, err := os.Create(codePath)
	if err != nil {
		return res.Response{
			SendUUID: id,
			Status:   "Не удалось создать файл",
			Error:    res.SystemError,
		}
	}

	// Запись кода в файл
	_, writeErr := file.WriteString(code)
	if writeErr != nil {
		return res.Response{
			SendUUID: id,
			Status:   "Ошибка при записи в файл",
			Error:    res.SystemError,
		}
	}
	file.Close()

	err = buildProgram(codePath, path, id)
	if err != nil {
		return res.Response{
			SendUUID: id,
			Status:   "Ошибка компиляции",
			Error:    res.DoesntCompile,
		}
	}

	ret := testRunner(path+"/"+id, test, checkRes)
	ret.SendUUID = id
	return ret
}

func buildProgram(codePath string, path string, nameFile string) error {
	//create bin file
	cmd := exec.Command("go", "build", "-o", nameFile, codePath)
	err := cmd.Run()
	if err != nil {
		return err
	}
	//move bin file
	cmd = exec.Command("mv", nameFile, path+"/")
	err = cmd.Run()
	if err != nil {
		return err
	}
	return nil
}

func testRunner(binPath string, test []string, checkRes []string) res.Response {
	if len(test) != len(checkRes) {
		return res.Response{
			Status: "Колличество тестов не соответствует колличеству кейсов.",
			Error:  res.WrongData,
		}
	}
	for i := 0; i < len(test); i++ {
		ret := runCase(binPath, test[i], checkRes[i])
		if len(ret) != 0 {
			return res.Response{
				Status: "Ошибка на кейсе",
				Error:  res.RuntimeError,
				Payload: res.Answer{
					TestCase: checkRes[i],
					Output:   ret,
				},
			}
		}
	}
	return res.OK()
}

func runCase(binPath string, test string, checkRes string) string {
	ctx, _ := context.WithTimeout(context.Background(), time.Second*2)
	done := make(chan struct{})
	defer close(done)

	echoCreate := func(in string) string {
		return "<(echo \"" + in + "\")"
	}
	cmd := exec.Command("sh", "-c", binPath+" "+echoCreate(test)+" | diff -wiy - "+echoCreate(checkRes))

	var out bytes.Buffer
	cmd.Stdout = &out

	var err error

	go func() {
		err = cmd.Run()
		done <- struct{}{}
	}()

	select {
	case <-ctx.Done():
		return "Time out"
	case <-done:
		break
	}

	if err != nil {
		var exitError *exec.ExitError
		if errors.As(err, &exitError) {
			if exitError.ExitCode() != 0 {
				ret := out.String()
				if ret == "\t\t\t\t\t\t\t      >\n" {
					return ""
				}
				return ret
			}
		}
	}

	return ""
}
