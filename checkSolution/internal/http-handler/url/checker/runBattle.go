package checkCode

import (
	"errors"
	"github.com/go-chi/render"
	res "github.com/moroshma/REST-ful-code-battle-platform/checkSolution/internal/lib/api/response"
	"io"
	"log/slog"
	"net/http"
)

type Request struct {
	CodeTask      string   `json:"code_task" swag:"description=Код для проверки"`
	TestCase      []string `json:"test_case" swag:"description=Массив тестовых случаев"`
	CorrectAnswer []string `json:"correct_answer" swag:"description=Массив правильных ответов, соответствующих тестовым случаям"`
}

type Response struct {
	Status   int `json:"status,omitempty" swag:"description=Код состояния, указывающий результат проверки кода"`
	FailTest int `json:"fail_test,omitempty" swag:"description=Количество неудачных тестовых случаев"`
}

type CodeRunner interface {
	Run(code string, test []string, checkRes []string) res.Response
}

// New создает новый обработчик для проверки решения
// @Summary Проверка решения
// @Description Проверка решения задачи
// @Tags checkSolution
// @Accept json
// @Produce json
// @Param checkSolution body Request true "Запрос на проверку решения"
// @Success 200 {object} Response
// @Router /checkSolution [post]
// @Param code_task body string true "Код для проверки"
// @Param test_case body []string true "Массив тестовых случаев"
// @Param correct_answer body []string true "Массив правильных ответов, соответствующих тестовым случаям"
func New(log *slog.Logger, codeRunner CodeRunner) http.HandlerFunc {
	return func(w http.ResponseWriter, r *http.Request) {
		var req Request

		err := render.DecodeJSON(r.Body, &req)
		if errors.Is(err, io.EOF) {
			// Такую ошибку встретим, если получили запрос с пустым телом.
			// Обработаем её отдельно
			log.Error("request body is empty")

			render.JSON(w, r, res.Error("empty request", res.WrongData))

			return
		}
		if err != nil {
			log.Error("failed to decode request body", err)

			render.JSON(w, r, res.Error("failed to decode request, ", res.WrongData))

			return
		}

		run := codeRunner.Run(req.CodeTask, req.TestCase, req.CorrectAnswer)
		render.JSON(w, r, run)
	}
}
