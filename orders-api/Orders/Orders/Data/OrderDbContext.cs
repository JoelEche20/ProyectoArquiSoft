using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Orders.Data.Entity;

namespace Orders.Data.Repository
{
    public class OrderDbContext: IdentityDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderEntity>().ToTable("Orders");
            modelBuilder.Entity<OrderEntity>().Property(a => a.Id).ValueGeneratedOnAdd();
        }


        public DbSet<OrderEntity> Orders { get; set; }
    }
}
