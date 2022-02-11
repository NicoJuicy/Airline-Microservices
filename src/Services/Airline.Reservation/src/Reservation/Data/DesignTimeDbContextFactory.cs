using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Reservation.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservationDbContext>
{
    public ReservationDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ReservationDbContext>();

        builder.UseSqlServer(
            "Data Source=.\\sqlexpress;Initial Catalog=ReservationDB;Persist Security Info=False;Integrated Security=SSPI");
        return new ReservationDbContext(builder.Options);
    }
}