#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "$ext_safeprojectname$.Api/$ext_safeprojectname$.Api.csproj" --configfile "NuGet.config" --disable-parallel
COPY . .
WORKDIR "/src/$ext_safeprojectname$.Api"
RUN dotnet build "$ext_safeprojectname$.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "$ext_safeprojectname$.Api.csproj" -c Release -o /app/publish

FROM base AS final
RUN apk add --no-cache icu-libs

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# set noninteractive installation
RUN export DEBIAN_FRONTEND=noninteractive
#install tzdata package
RUN apk update
RUN apk add --update tzdata

ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
ENV ASPNETCORE_URLS=http://+:80

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "$ext_safeprojectname$.Api.dll"]