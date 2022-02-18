FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
WORKDIR /app

# Setup working directory for the project
WORKDIR /app
COPY ./src/BuildingBlocks/BuildingBlocks.csproj ./BuildingBlocks/
COPY ./src/Services/Airline.Passenger/src/Passenger/Passenger.csproj ./Services/Airline.Passenger/src/Passenger/
COPY ./src/Services/Airline.Passenger/src/Passenger.Api/Passenger.Api.csproj ./Services/Airline.Passenger/src/Passenger.Api/


# Restore nuget packages
RUN dotnet restore ./Services/Airline.Passenger/src/Passenger.Api/Passenger.Api.csproj

# Copy project files
COPY ./src/BuildingBlocks ./BuildingBlocks/
COPY ./src/Services/Airline.Passenger/src/Passenger/  ./Services/Airline.Passenger/src/Passenger/
COPY ./src/Services/Airline.Passenger/src/Passenger.Api/  ./Services/Airline.Passenger/src/Passenger.Api/

# Build project with Release configuration
# and no restore, as we did it already

RUN ls
RUN dotnet build  -c Release --no-restore ./Services/Airline.Passenger/src/Passenger.Api/Passenger.Api.csproj

WORKDIR /app/Services/Airline.Passenger/src/Passenger.Api

# Publish project to output folder
# and no build, as we did it already
RUN dotnet publish -c Release --no-build -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Setup working directory for the project
WORKDIR /app
COPY --from=builder /app/Services/Airline.Passenger/src/Passenger.Api/out  .

ENV ASPNETCORE_URLS https://*:5012, http://*:6012
ENV ASPNETCORE_ENVIRONMENT docker  

ENTRYPOINT ["dotnet", "Passenger.Api.dll"]

