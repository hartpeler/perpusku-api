using Microsoft.EntityFrameworkCore;
using perpusku_api.Model.Data.Auth;
using perpusku_api.Model.Data.Books;
using perpusku_api.Model.Data.Transactions;
using Microsoft.Extensions.Configuration;
public class DataContext : DbContext
{
    #region initializer area
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration) // Inject IConfiguration
    {
        _configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
    #endregion

    #region Tables
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Transactioncs> Transactions { get; set; }
    public DbSet<TransactionDetail> TransactionDetails { get; set; }
    #endregion

}