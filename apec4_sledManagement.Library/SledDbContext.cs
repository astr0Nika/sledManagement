using apec4_sledManagement.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace apec4_sledManagement.Library;
public class SledDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Sled> Sleds { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // change connection string to your own
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=apec4_sledManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
