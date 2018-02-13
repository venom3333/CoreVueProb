using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class MyDataContext : DbContext
    {
        public DbSet<MyData> MyDatas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public MyDataContext(DbContextOptions<MyDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyDataCategory>()
                .HasKey(mdc => new { mdc.MyDataId, mdc.CategoryId });

            modelBuilder.Entity<MyDataCategory>()
                .HasOne(mdc => mdc.MyData)
                .WithMany(md => md.MyDataCategory)
                .HasForeignKey(mdc => mdc.MyDataId);

            modelBuilder.Entity<MyDataCategory>()
                .HasOne(mdc => mdc.Category)
                .WithMany(c => c.MyDataCategory)
                .HasForeignKey(mdc => mdc.CategoryId);
        }
    }
}
