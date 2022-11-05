using Microsoft.EntityFrameworkCore;
using Web.RazorPages01.Models;

namespace Web.RazorPages01.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }
    
    public DbSet<Movie>? Movies { get; set; }
}