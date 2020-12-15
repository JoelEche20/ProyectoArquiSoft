using Microsoft.EntityFrameworkCore;
using review_api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace review_api.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CommentaryEntity>().ToTable("Comments");
            modelBuilder.Entity<CommentaryEntity>().Property(a => a.Id).ValueGeneratedOnAdd();

        }

        public DbSet<CommentaryEntity> Comments { get; set; }
    }
}
