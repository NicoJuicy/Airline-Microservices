dotnet ef migrations add initial --context ReservationDbContext -o "Data\Migrations"
dotnet ef database update --context ReservationDbContext
