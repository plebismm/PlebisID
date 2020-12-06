#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Plebis.Membership/Plebis.Membership.csproj", "Plebis.Membership/"]
RUN dotnet restore "Plebis.Membership/Plebis.Membership.csproj"
COPY . .
WORKDIR "/src/Plebis.Membership"
RUN dotnet build "Plebis.Membership.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Plebis.Membership.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Plebis.Membership.dll"]