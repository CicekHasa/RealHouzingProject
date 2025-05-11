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
    public DbSet<ServiceCategories> ServiceCategories { get; set; }
    public DbSet<MainContent> MainContents { get; set; }
    public DbSet<FeatureCard> FeatureCards { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<New> News { get; set; }
    public DbSet<Subscribe> Subscribes { get; set; }
    public DbSet<About> AboutUs { get; set; }
    public DbSet<CompanyValue> CompanyValues { get; set; }
    public DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
}

