using CustomerPurchaseRecord.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace CustomerPurchaseRecord.DataService.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<TransactionDetails> TransactionDetails { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TransactionDetails>(entity =>
        {
            entity.HasOne(t => t.Customer)
            .WithMany(t => t.TransactionDetails)
            .HasForeignKey(t => t.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_TransactionDetail_Customer");
        });
    }
}
