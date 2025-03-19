#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 3030
ENV ASPNETCORE_URLS=http://*:3030
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ContactsDeleteProducer.Api/FIAP.TechChallenge.ContactsDeleteProducer.Api.csproj", "ContactsDeleteProducer.Api/"]
COPY ["ContactsDeleteProducer.Application/FIAP.TechChallenge.ContactsDeleteProducer.Application.csproj", "ContactsDeleteProducer.Application/"]
COPY ["ContactsDeleteProducer.Domain/FIAP.TechChallenge.ContactsDeleteProducer.Domain.csproj", "ContactsDeleteProducer.Domain/"]
COPY ["ContactsDeleteProducer.Infrastructure/FIAP.TechChallenge.ContactsDeleteProducer.Infrastructure.csproj", "ContactsDeleteProducer.Infrastructure/"]
COPY ["ContactsDeleteProducer.Integrations/FIAP.TechChallenge.ContactsDeleteProducer.Integrations.csproj", "ContactsDeleteProducer.Integrations/"]
RUN dotnet restore "./ContactsDeleteProducer.Api/FIAP.TechChallenge.ContactsDeleteProducer.Api.csproj"
COPY . .
WORKDIR "/src/ContactsDeleteProducer.Api"
RUN dotnet build "./FIAP.TechChallenge.ContactsDeleteProducer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FIAP.TechChallenge.ContactsDeleteProducer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FIAP.TechChallenge.ContactsDeleteProducer.Api.dll"]