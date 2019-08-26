FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["graph.csproj", ""]
COPY ["NuGet.Config", ""]
RUN dotnet restore "./graph.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "graph.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "graph.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "graph.dll"]