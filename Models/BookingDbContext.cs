using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database_Connect.Models;

public partial class BookingDbContext : DbContext
{
    public BookingDbContext()
    {
       
    }

    public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RightsTbl> RightsTbls { get; set; }

    public virtual DbSet<RoleTbl> RoleTbls { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    public virtual DbSet<TblAll> TblAlls { get; set; }

    public virtual DbSet<TblTest> TblTests { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookingDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RightsTbl>(entity =>
        {
            entity.HasKey(e => e.RightsId);

            entity.ToTable("RightsTbl");

            entity.Property(e => e.RightsId).ValueGeneratedNever();
            entity.Property(e => e.Rights).IsUnicode(false);
        });

        modelBuilder.Entity<RoleTbl>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("RoleTbl");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Rights).WithMany(p => p.RoleTbls)
                .HasForeignKey(d => d.RightsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleTbl_RightsTbl");
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table_1");

            entity.Property(e => e.Somevalue)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("somevalue");
        });

        modelBuilder.Entity<TblAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblALL");

            entity.Property(e => e.ContactDetails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Rights).IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblTest");

            entity.Property(e => e.FirstName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.ToTable("UserTbl");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContactDetails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserTbls)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTbl_RoleTbl");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
