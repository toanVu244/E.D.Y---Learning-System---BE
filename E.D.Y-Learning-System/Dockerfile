#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5279

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["E.D.Y-Learning-System/E.D.Y-Learning-System.csproj", "E.D.Y-Learning-System/"]
COPY ["BusinessObject/BusinessObject.csproj", "BusinessObject/"]
COPY ["E.D.Y-Serivce/E.D.Y-Serivce.csproj", "E.D.Y-Serivce/"]
COPY ["E.D.Y-Repository/E.D.Y-Repository.csproj", "E.D.Y-Repository/"]
RUN dotnet restore "E.D.Y-Learning-System/E.D.Y-Learning-System.csproj"
COPY . .
WORKDIR "/src/E.D.Y-Learning-System"
RUN dotnet build "E.D.Y-Learning-System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "E.D.Y-Learning-System.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E.D.Y-Learning-System.dll"]