FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["cms.web/cms.web.csproj", "cms.web/"]
RUN dotnet restore "cms.web/cms.web.csproj"
COPY . .
WORKDIR "/src/cms.web"
RUN dotnet build "cms.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "cms.web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "cms.web.dll"]