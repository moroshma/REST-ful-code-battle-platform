package response

type Answer struct {
	TestCase string `json:"testCase"`
	Output   string `json:"output"`
}

type Response struct {
	SendUUID string `json:"sendUUID"`
	Status   string `json:"status"`
	Error    string `json:"error,omitempty"`
	Payload  Answer `json:"answer,omitempty"`
}

const (
	StatusOK      = "OK"
	StatusError   = "Error"
	WrongData     = "Wrong Data"
	TimeOut       = "Time out"
	RuntimeError  = "RuntimeError"
	DoesntCompile = "Doesnt Compile"
	SystemError   = "System Error"
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
