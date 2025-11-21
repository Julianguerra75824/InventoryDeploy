using InventoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options) { }

    public DbSet<Medicine> Medicines => Set<Medicine>();
    public DbSet<Procedure> Procedures => Set<Procedure>();
    public DbSet<DiagnosticTest> DiagnosticTests => Set<DiagnosticTest>();
}
