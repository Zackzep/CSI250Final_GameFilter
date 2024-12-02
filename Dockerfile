# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["<CSI250Final_GameFilter>.csproj", "./"]
RUN dotnet restore "./<CSI250Final_GameFilter>.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet publish "<CSI250Final_GameFilter>.csproj" -c Release -o /app/publish

# Use the runtime image to run the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "<CSI250Final_GameFilter>.dll"]