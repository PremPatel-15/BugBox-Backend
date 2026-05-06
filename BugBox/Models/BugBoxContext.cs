using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BugBox.Models;

public partial class BugBoxContext : DbContext
{
    public BugBoxContext()
    {
    }

    public BugBoxContext(DbContextOptions<BugBoxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bug> Bugs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bug>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bugs__3213E83F11F13FCF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("assignedTo");
            entity.Property(e => e.Category)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Priority)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("priority");
            entity.Property(e => e.Rootcause)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("rootcause");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
