FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["Mari7.csproj", "./"]
RUN dotnet restore "./Mari7.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Mari7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mari7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mari7.dll"]
