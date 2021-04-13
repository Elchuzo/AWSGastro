using GastroAvancesWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GastroAvancesWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<usuario, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<IdentityUser<int>>(entity =>
            {
                entity.ToTable(name: "AspNetUser");
                //entity.Property(e => e.Id).HasColumnName("AspNetUserId");
            });

            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.ToTable(name: "AspNetRole");

            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("AspNetUserClaim");

            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("AspNetUserLogin");

            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("AspNetRoleClaim");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("AspNetUserRole");

            });


            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("AspNetUserToken");

            });


        }
    }
}
