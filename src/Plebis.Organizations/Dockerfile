#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Plebis.Organizations/Plebis.Organizations.csproj", "Plebis.Organizations/"]
RUN dotnet restore "Plebis.Organizations/Plebis.Organizations.csproj"
COPY . .
WORKDIR "/src/Plebis.Organizations"
RUN dotnet build "Plebis.Organizations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Plebis.Organizations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Plebis.Organizations.dll"]