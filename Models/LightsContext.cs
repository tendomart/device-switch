using Microsoft.EntityFrameworkCore;

namespace HomeControlApi.Models;

public class LightsContext : DbContext
{
    public LightsContext(DbContextOptions<LightsContext> options)
        : base(options)
    {
    }

    public DbSet<Light> Lights { get; set; } = null!;
}