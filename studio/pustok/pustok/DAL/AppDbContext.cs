using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustok.Models;

namespace pustok.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
    }
}
