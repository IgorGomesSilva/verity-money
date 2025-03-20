using VerityMoney.Domain;
using Microsoft.EntityFrameworkCore;

namespace VerityMoney.Infra.Data;

 public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

}
