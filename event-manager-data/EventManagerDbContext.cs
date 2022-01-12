using Microsoft.EntityFrameworkCore;

namespace event_manager_data;

public class EventManagerDbContext : DbContext
{
    public DbSet<DatiEvento> Eventi { get; set; }
    
    public EventManagerDbContext(DbContextOptions options)
        : base(options) { }
}