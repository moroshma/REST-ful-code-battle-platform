package response

type Response struct {
	Status string `json:"status"`
	Error  string `json:"error,omitempty"`
}

const (
	StatusOK      = "OK"
	StatusError   = "Error"
	WrongData     = "Wrong Data"
	TimeOut       = "Time out"
	WrongAnswer   = "Wrong Answer"
	DoesntCompile = "Doesnt Compile"
)

func OK() Response {
	return Response{
		Status: StatusOK,
	}
}

func Error(msg string, err string) Response {
	return Response{
		Status: msg,
		Error:  err,
	}
}
