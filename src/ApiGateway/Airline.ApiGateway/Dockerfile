FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
WORKDIR /src

# Setup working directory for the project
WORKDIR /src
COPY ./src/BuildingBlocks/BuildingBlocks.csproj ./BuildingBlocks/
COPY ./src/ApiGateway/Airline.ApiGateway/src/Airline.ApiGateway.csproj ./ApiGateway/Airline.ApiGateway/src/


# Restore nuget packages
RUN dotnet restore ./ApiGateway/Airline.ApiGateway/src/Airline.ApiGateway.csproj

# Copy project files
COPY ./src/BuildingBlocks ./BuildingBlocks/
COPY ./src/ApiGateway/Airline.ApiGateway/src  ./ApiGateway/Airline.ApiGateway/src/

# Build project with Release configuration
# and no restore, as we did it already

RUN ls
RUN dotnet build  -c Release --no-restore ./ApiGateway/Airline.ApiGateway/src/Airline.ApiGateway.csproj

WORKDIR /src/ApiGateway/Airline.ApiGateway/src

# Publish project to output folder
# and no build, as we did it already
RUN dotnet publish -c Release --no-build -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Setup working directory for the project
WORKDIR /app
COPY --from=builder /src/ApiGateway/Airline.ApiGateway/src/out  .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Airline.ApiGateway.dll"]

