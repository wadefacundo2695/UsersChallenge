#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UsersChallenge.API/UsersChallenge.API.csproj", "UsersChallenge.API/"]
RUN dotnet restore "UsersChallenge.API/UsersChallenge.API.csproj"
COPY ["UsersChallenge.Domain/UsersChallenge.Domain.csproj", "UsersChallenge.Domain/"]
RUN dotnet restore "UsersChallenge.Domain/UsersChallenge.Domain.csproj"
COPY ["UsersChallenge.Application/UsersChallenge.Application.csproj", "UsersChallenge.Application/"]
RUN dotnet restore "UsersChallenge.Application/UsersChallenge.Application.csproj"
COPY ["UsersChallenge.Infrastructure/UsersChallenge.Infrastructure.csproj", "UsersChallenge.Infrastructure/"]
RUN dotnet restore "UsersChallenge.Infrastructure/UsersChallenge.Infrastructure.csproj"
COPY . .
WORKDIR "/src/UsersChallenge.API"
RUN dotnet build "UsersChallenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UsersChallenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsersChallenge.API.dll"]