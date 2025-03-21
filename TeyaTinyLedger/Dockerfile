# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Restore dependencies
COPY ["TeyaTinyLedger.csproj", "TeyaTinyLedger/"]
RUN dotnet restore "TeyaTinyLedger/TeyaTinyLedger.csproj"

# Copy the rest of the application code
COPY [".", "TeyaTinyLedger/"]

# Build the application
WORKDIR /src/TeyaTinyLedger
RUN dotnet build "TeyaTinyLedger.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "TeyaTinyLedger.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
ENV ASPNETCORE_HTTP_PORTS=5000
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeyaTinyLedger.dll"]