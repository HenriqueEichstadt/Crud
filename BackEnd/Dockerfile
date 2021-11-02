
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Crud.Api/Crud.Api.csproj", "Crud.Api/"]
COPY ["Crud.DataAccess/Crud.DataAccess.csproj", "Crud.DataAccess/"]
COPY ["Crud.Models/Crud.Models.csproj", "Crud.Models/"]
COPY ["Crud.IoC/Crud.IoC.csproj", "Crud.IoC/"]
RUN dotnet restore "Crud.Api/Crud.Api.csproj"
COPY . .
RUN dotnet publish -c debug -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Crud.Api.dll"]