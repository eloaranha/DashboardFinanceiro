FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5277

ENV ASPNETCORE_URLS=http://+:5277

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["DashboardFinanceiro.csproj", "./"]
RUN dotnet restore "DashboardFinanceiro.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DashboardFinanceiro.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "DashboardFinanceiro.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DashboardFinanceiro.dll"]
