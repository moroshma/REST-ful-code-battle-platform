build:
	CONFIG_PATH=./config.yaml go build -o bin/app cmd/main.go

run: build
	CONFIG_PATH=./config.yaml ./bin/app

install_swagger:
	go install github.com/swaggo/swag/cmd/swag@latest
	go install github.com/swaggo/http-swagger@latest

generate_swagger:
	swag init -g cmd/main.go


# Название вашего Docker образа
IMAGE_NAME=my-golang-app

# Число используемых ядер CPU и ограничение памяти
CPUS=4
MEMORY=512m

# Создание Docker образа
build:
	docker build -t $(IMAGE_NAME) .

# Запуск контейнера из вашего образа с ограничениями ресурсов
run:
	docker run --rm --cpus=$(CPUS) --memory=$(MEMORY) --network="none" $(IMAGE_NAME)

# Удаление образа
clean:
	docker rmi $(IMAGE_NAME)

# Пометьте .PHONY для команд, которые не представляют файлы
.PHONY: build run clean
