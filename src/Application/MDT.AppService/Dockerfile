#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Application/MDT.AppService/MDT.AppService.csproj", "src/Application/MDT.AppService/"]
COPY ["src/Infrastructure/EntryPoint/MDT.Web/MDT.Web.csproj", "src/Infrastructure/EntryPoint/MDT.Web/"]
COPY ["src/Domain/MDT.Model/MDT.Model.csproj", "src/Domain/MDT.Model/"]
COPY ["src/Domain/MDT.UseCase/MDT.UseCase.csproj", "src/Domain/MDT.UseCase/"]
COPY ["src/Infrastructure/DrivenAdapter/MDT.SupabaseDb/MDT.SupabaseDb.csproj", "src/Infrastructure/DrivenAdapter/MDT.SupabaseDb/"]
RUN dotnet restore "src/Application/MDT.AppService/MDT.AppService.csproj"
COPY . .
WORKDIR "/src/src/Application/MDT.AppService"
RUN dotnet build "MDT.AppService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MDT.AppService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MDT.AppService.dll"]