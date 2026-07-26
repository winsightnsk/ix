using ix.DataSource.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.DataSource.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<TimeScaleEntity> Values { get; set; }
    public DbSet<FileEntity> Files { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TimeScaleEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            entity.HasOne<FileEntity>()
                .WithMany(f => f.Values) 
                .HasForeignKey(e => e.FileId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(e => e.FileId);
        });

        modelBuilder.Entity<FileEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();
            entity.HasMany(f => f.Values)
                .WithOne()
                .HasForeignKey(e => e.FileId);
            entity.HasIndex(e => e.FileName)
                .IsUnique();
        });
    }

}
