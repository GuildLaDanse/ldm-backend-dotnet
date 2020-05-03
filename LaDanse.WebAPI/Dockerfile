#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LaDanse.WebAPI/LaDanse.WebAPI.csproj", "LaDanse.WebAPI/"]
RUN dotnet restore "LaDanse.WebAPI/LaDanse.WebAPI.csproj"
COPY . .
WORKDIR "/src/LaDanse.WebAPI"
RUN dotnet build "LaDanse.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LaDanse.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LaDanse.WebAPI.dll"]