using Microsoft.EntityFrameworkCore;
using volunteer.Model;

namespace volunteer.Data;

public class VolunteerContext : DbContext
{
    public DbSet<VolunteerModel> Volunteers { get; private set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=volunteers;");
        base.OnConfiguring(optionsBuilder);
    }
}