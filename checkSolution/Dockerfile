# Стадия сборки
FROM fedora:latest AS build

# Установка Go 1.22
RUN dnf -y update && dnf -y install golang && go version

WORKDIR /src

# Копирование go.mod и go.sum
COPY go.mod go.sum ./

# Загрузка зависимостей
RUN go mod download

# Копирование исходного кода
COPY . .

# Сборка приложения
RUN go build -o /app/main cmd/main.go

# Стадия запуска
FROM fedora:latest

WORKDIR /app

# Копирование исполняемого файла из стадии сборки
COPY --from=build /app/main /app/main

# Копирование файла конфигурации
COPY --from=build /src/config.yaml ./config.yaml

# Установка переменной окружения
ENV CONFIG_PATH=./config.yaml

# Запуск приложения
CMD ["/app/main"]