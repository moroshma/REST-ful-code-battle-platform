package CodeRunner

import res "github.com/moroshma/REST-ful-code-battle-platform/checkSolution/internal/lib/api/response"

type CodeRunner struct {
	res.Response
}

func (cr CodeRunner) Run(code string, test [][]string, checkRes [][]string) res.Response {
	return res.Response{
		Status: "oki doki",
		Error:  res.StatusOK,
	}

}
