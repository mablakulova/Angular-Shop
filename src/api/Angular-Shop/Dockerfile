FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["./Angular-Shop.API/Angular-Shop.API.cproj", "src/Angular-Shop.API/"]
COPY ["./Angular-Shop.Data/Angular-Shop.Data.cproj", "src/Angular-Shop.Data/"]
COPY ["./Angular-Shop.Domain/Angular-Shop.Domain.cproj", "src/Angular-Shop.Domain/"]
COPY ["./Angular-Shop.UnitTests/Angular-Shop.UnitTests.cproj", "src/Angular-Shop.UnitTests/"]

RUN dotnet restore "src/Angular-Shop.API/Angular-Shop.API.csproj"

COPY . .

# run build over the API project
WORKDIR "/src/Angular-Shop.API/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "Angular-Shop.dll" ]