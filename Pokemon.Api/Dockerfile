#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pokemon.Api/Pokemon.Api.csproj", "Pokemon.Api/"]
COPY ["Pokemon.ServiceProvider/Pokemon.ServiceProvider.csproj", "Pokemon.ServiceProvider/"]
COPY ["Pokemon.Model/Pokemon.Model.csproj", "Pokemon.Model/"]
COPY ["Pokemon.Common/Pokemon.Common.csproj", "Pokemon.Common/"]
COPY ["Pokemon.Redis/Pokemon.CachingService.csproj", "Pokemon.Redis/"]
RUN dotnet restore "Pokemon.Api/Pokemon.Api.csproj"
COPY . .
WORKDIR "/src/Pokemon.Api"
RUN dotnet build "Pokemon.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pokemon.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pokemon.Api.dll"]
