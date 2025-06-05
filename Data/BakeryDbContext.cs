// Student ID: 00013630
using BakeryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryApi.Data;

public class BakeryDbContext : DbContext
{
    public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
}
