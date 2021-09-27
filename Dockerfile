#Get dotnet sdk and make directory named app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj to app directory and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build // Copy root to app directory
#-o out : in app make folder named app then publish ther
# COPY ../engine/examples ./  OR
COPY . ./
RUN dotnet publish -c Release -o out

#Get dotnet runtime / Build runtime image / Run project
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PostService.dll"]