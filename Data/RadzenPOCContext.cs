using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RadzenPOC.Data;

public class RadzenPOCContext : DbContext
{
    public RadzenPOCContext(DbContextOptions<RadzenPOCContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}
