using BasketTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<CategoryProducts> CategoryProducts { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<WeekendDiscount> WeekendDiscounts { get; set; }
    }
}
