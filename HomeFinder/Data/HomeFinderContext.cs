using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeFinder.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HomeFinder.Data
{
    public class HomeFinderContext :  IdentityDbContext<IdentityUser>
    {
        public HomeFinderContext (DbContextOptions<HomeFinderContext> options)
            : base(options)
        {

        }


        public DbSet<HomeFinder.Models.HouseDetails> HouseDetails { get; set; } = default!;
        public DbSet<HouseImage> HouseImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HouseImage>()
                .HasOne(hi => hi.HouseDetails)
                .WithMany(hd => hd.HouseImages)
                .HasForeignKey(hi => hi.HouseId);

            // Additional configurations or constraints
            base.OnModelCreating(modelBuilder);

        }

    }
}
