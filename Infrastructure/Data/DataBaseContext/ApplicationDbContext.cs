using Domain.Models;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DataBaseContext;

public class ApplicationDbContext: DbContext
{
    public DbSet<Topic> Topics => Set<Topic>();
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
         
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Topic>()
            .Property(t => t.Id)
            .HasConversion(
                id => id.Value,
                value => TopicId.Of(value)
            );

        modelBuilder.Entity<Topic>()
            .OwnsOne(topic => topic.Location, location =>
            {
                location.Property(l => l.City).HasColumnName("City");
                location.Property(l => l.Street).HasColumnName("Street");
            });
    }
}
