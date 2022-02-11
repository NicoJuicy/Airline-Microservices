dotnet ef migrations add initial --context IdentityContext -o "Infrastructure\Data\Migrations"
dotnet ef database update --context IdentityContext
