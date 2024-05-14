build:
	CONFIG_PATH=./config.yaml go build -o bin/app cmd/main.go

run: build
	CONFIG_PATH=./config.yaml ./bin/app

install_swagger:
	go install github.com/swaggo/swag/cmd/swag@latest
	go get -u github.com/swaggo/http-swagger

generate_swagger:
	swag init -g cmd/main.go

