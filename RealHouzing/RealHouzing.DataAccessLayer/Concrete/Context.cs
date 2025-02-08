using Microsoft.EntityFrameworkCore;
using RealHouzing.EntityLayer.Concrete;
namespace RealHouzing.DataAccessLayer.Concrete;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=HASANCICEKK\\MSSQLSERVER01; initial catalog=RealHouzingApiDb; integrated security=true");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}

