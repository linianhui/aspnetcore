AspNetCore 2 Example


# docker-compose.yml (docker platform)
```sh
## start docker
docker-compose up --detach --build

## stop docker
docker-compose down
```

# build.ps1 (windows platform)

1. `.\build.ps1 -help`：帮助信息。
1. `.\build.ps1 -target deploy-iis`：部署到本机IIS。
