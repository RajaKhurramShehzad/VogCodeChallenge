#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

############################ BUILD ############################
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

ARG NuGetPassword
RUN apt-get update && apt-get install -y locales
RUN sed -i -e 's/# en_US.UTF-8 UTF-8/en_US.UTF-8 UTF-8/' /etc/locale.gen && dpkg-reconfigure --frontend=noninteractive locales && update-locale LANG=en_US.UTF-8
ENV LANG en_US.UTF-8
ENV LC_ALL=en_US.UTF-8

RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash


COPY ["VogCodeChallenge.API/VogCodeChallenge.API.csproj", "VogCodeChallenge.API/"]
COPY ["VogCodeChallenge.BLL/VogCodeChallenge.BLL.csproj", "VogCodeChallenge.BLL/"]
RUN dotnet restore "VogCodeChallenge.API/VogCodeChallenge.API.csproj"
COPY . .
WORKDIR "/src/VogCodeChallenge.API"
RUN dotnet build "VogCodeChallenge.API.csproj" -c Release -o /app/build

############################ PUBLISH ############################
FROM build AS publish
WORKDIR /src/VogCodeChallenge.API/
RUN dotnet publish "VogCodeChallenge.API.csproj" -c Release -o /app/publish
COPY --from=build /app/VogCodeChallenge.API.xml /app/

######################### Env ####################################
FROM base AS final

ENV ASPNETCORE_URLS=http://+:5000
ENV DeployVersion=0.0.0
ENV DeployEnvironment=DEV
ENV EnableDBConnectivity=false
ENV FunctionName=mockFuncrion
ENV AWSKey=mockKey
ENV AWSSecret=mockSecret

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VogCodeChallenge.API.dll"]
