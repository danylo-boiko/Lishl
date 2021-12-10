FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Lishl.Core/*.csproj ./Lishl.Core/

COPY Lishl.Infrastructure.MongoDb/*.csproj ./Lishl.Infrastructure.MongoDb/
COPY Lishl.Infrastructure.PostgreSql/*.csproj ./Lishl.Infrastructure.PostgreSql/

COPY Lishl.Authentication.Core/*.csproj ./Lishl.Authentication.Core/
COPY Lishl.Authentication/*.csproj ./Lishl.Authentication/

COPY Lishl.Users.Api/*.csproj ./Lishl.Users.Api/
COPY Lishl.Links.Api/*.csproj ./Lishl.Links.Api/
COPY Lishl.QRCodes.Api/*.csproj ./Lishl.QRCodes.Api/
COPY Lishl.GraphQL/*.csproj ./Lishl.GraphQL/

RUN dotnet restore

# Copy everything else and build app
COPY Lishl.Core/. ./Lishl.Core/
COPY Lishl.Authentication.Core/. ./Lishl.Authentication.Core/
COPY Lishl.Infrastructure.PostgreSql/. ./Lishl.Infrastructure.PostgreSql/
COPY Lishl.Users.Api/. ./Lishl.Users.Api/

WORKDIR /app/Lishl.Users.Api

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/Lishl.Users.Api/out ./
ENTRYPOINT ["dotnet", "Lishl.Users.Api.dll"]