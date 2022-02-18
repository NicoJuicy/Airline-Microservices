FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
WORKDIR /app

# Setup working directory for the project
WORKDIR /app
COPY ./src/BuildingBlocks/BuildingBlocks.csproj ./BuildingBlocks/
COPY ./src/Services/Airline.Reservation/src/Reservation/Reservation.csproj ./Services/Airline.Reservation/src/Reservation/
COPY ./src/Services/Airline.Reservation/src/Reservation.Api/Reservation.Api.csproj ./Services/Airline.Reservation/src/Reservation.Api/


# Restore nuget packages
RUN dotnet restore ./Services/Airline.Reservation/src/Reservation.Api/Reservation.Api.csproj

# Copy project files
COPY ./src/BuildingBlocks ./BuildingBlocks/
COPY ./src/Services/Airline.Reservation/src/Reservation/  ./Services/Airline.Reservation/src/Reservation/
COPY ./src/Services/Airline.Reservation/src/Reservation.Api/  ./Services/Airline.Reservation/src/Reservation.Api/

# Build project with Release configuration
# and no restore, as we did it already

RUN ls
RUN dotnet build  -c Release --no-restore ./Services/Airline.Reservation/src/Reservation.Api/Reservation.Api.csproj

WORKDIR /app/Services/Airline.Reservation/src/Reservation.Api

# Publish project to output folder
# and no build, as we did it already
RUN dotnet publish -c Release --no-build -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Setup working directory for the project
WORKDIR /app
COPY --from=builder /app/Services/Airline.Reservation/src/Reservation.Api/out  .

ENV ASPNETCORE_URLS https://*:5010, http://*:6010
ENV ASPNETCORE_ENVIRONMENT docker  

ENTRYPOINT ["dotnet", "Reservation.Api.dll"]

