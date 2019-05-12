FROM microsoft/dotnet:2.2-sdk-alpine AS builder

COPY . /src

WORKDIR /src

RUN dotnet publish ./web.apis/web.apis.csproj --output /publish



FROM microsoft/dotnet:2.2.0-aspnetcore-runtime-alpine

COPY --from=builder /publish /app

WORKDIR /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Web.Apis.dll"]