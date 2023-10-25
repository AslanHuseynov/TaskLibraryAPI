using Library.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.DB;

public class DBContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-THVOU75\\MSSQLSERVER02;Database=LibraryAPI1;Trusted_Connection=true;TrustServerCertificate=true;", b => b.MigrationsAssembly("LibraryAPI"));
    }
}