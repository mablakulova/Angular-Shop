FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./Angular-Shop.Data/Angular-Shop.Data.csproj", "src/Angular-Shop.Data/"]
COPY ["./Angular-Shop.API/Angular-Shop.API.csproj", "src/Angular-Shop.API/"]
COPY ["./Angular-Shop.UnitTests/Angular-Shop.UnitTests.csproj", "src/Angular-Shop.UnitTests/"]
COPY ["./Angular-Shop.Domain/Angular-Shop.Domain.csproj", "src/Angular-Shop.Domain/"]

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "src/Angular-Shop.API/Angular-Shop.API.csproj"

#Copy all the source code into the Build Container
COPY . .

# Run dotnet publish in the Build Container
# Generates output available in /app/build
WORKDIR "/src/Angular-Shop.API/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Step 2 - Continuing from the End of Step 1 #
# Second Stage - Pick an Image with only dotnetcore Runtime
FROM base AS runtime

# Set the Directory as /app
# All consecutive operations happen under /app
WORKDIR /app

# Copy the dlls generated under /app/out of the previous step
COPY --from=publish /app/publish .

# Set the Entrypoint for the Container
# Entrypoint is for executables (such as exe, dll)
ENTRYPOINT [ "dotnet", "Angular-Shop.dll" ]

