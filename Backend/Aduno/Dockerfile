FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReSign.WebAPI/ReSign.WebAPI.csproj", "ReSign.WebAPI/"]
COPY ["ReSign.Database.Logic/ReSign.Database.Logic.csproj", "ReSign.Database.Logic/"]
COPY ["ReSign.Common.Logic/ReSign.Common.Logic.csproj", "ReSign.Common.Logic/"]
RUN dotnet restore "ReSign.WebAPI/ReSign.WebAPI.csproj"
COPY . .
WORKDIR "/src/ReSign.WebAPI"
RUN dotnet build "ReSign.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReSign.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReSign.WebAPI.dll"]