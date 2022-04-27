FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aduno.WebAPI/Aduno.WebAPI.csproj", "Aduno.WebAPI/"]
COPY ["Aduno.Database.Logic/Aduno.Database.Logic.csproj", "Aduno.Database.Logic/"]
COPY ["Aduno.Common.Logic/Aduno.Common.Logic.csproj", "Aduno.Common.Logic/"]
RUN dotnet restore "Aduno.WebAPI/Aduno.WebAPI.csproj"
COPY . .
WORKDIR "/src/Aduno.WebAPI"
RUN dotnet build "Aduno.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aduno.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aduno.WebAPI.dll"]