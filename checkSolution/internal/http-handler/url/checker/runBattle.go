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
	CodeTask      string   `json:"code_task"`
	TestCase      []string `json:"test_case"`
	CorrectAnswer []string `json:"correct_answer"`
}

type Response struct {
	Status   int `json:"status,omitempty"`
	FailTest int `json:"fail_test,omitempty"`
}

type CodeRunner interface {
	Run(code string, test []string, checkRes []string) res.Response
}

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
