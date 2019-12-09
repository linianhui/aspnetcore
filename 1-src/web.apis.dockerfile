FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS builder

COPY . /src

WORKDIR /src

RUN dotnet publish ./web.apis/web.apis.csproj --output /publish



FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine

COPY --from=builder /publish /app

WORKDIR /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Web.Apis.dll"]