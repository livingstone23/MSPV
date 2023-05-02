#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 80
EXPOSE 443



FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["PVM.Services.Gestpro/PVM.Service.Gestpro.csproj", "PVM.Services.Gestpro/"]
COPY ["PVM.SharedLibrary/PVM.SharedLibrary.csproj", "PVM.SharedLibrary/"]
RUN dotnet restore "PVM.Services.Gestpro/PVM.Service.Gestpro.csproj"
COPY . .
WORKDIR "/src/PVM.Services.Gestpro"
RUN dotnet build "PVM.Service.Gestpro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PVM.Service.Gestpro.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PVM.Service.Gestpro.dll"]