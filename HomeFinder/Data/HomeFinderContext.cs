using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeFinder.Data
{
    public class HomeFinderContext : DbContext
    {
        public HomeFinderContext (DbContextOptions<HomeFinderContext> options)
            : base(options)
        {
        }
        //public DbSet<HouseDetailsViewModel> Images { get; set; }

        public DbSet<HomeFinder.Models.HouseDetails> HouseDetails { get; set; } = default!;

        public DbSet<HomeFinder.Models.UserDetails>? UserDetails { get; set; }
    }
}
