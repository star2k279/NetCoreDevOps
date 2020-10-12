FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DotNetCoreDockerized/DotNetCoreDockerized.csproj", "DotNetCoreDockerized/"]
RUN dotnet restore "DotNetCoreDockerized/DotNetCoreDockerized.csproj"
COPY . .
WORKDIR "/src/DotNetCoreDockerized"
RUN dotnet build "DotNetCoreDockerized.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DotNetCoreDockerized.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DotNetCoreDockerized.dll"]