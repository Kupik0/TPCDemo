using Finbuckle.MultiTenant;
using TPCDemo.Application.Common.Events;
using TPCDemo.Application.Common.Interfaces;
using TPCDemo.Domain.Catalog;
using TPCDemo.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TPCDemo.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Hayvan> Hayvans => Set<Hayvan>();
    public DbSet<Kedi> Kedis => Set<Kedi>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Hayvan>().UseTpcMappingStrategy();
   
        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}