using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapptest.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomerList> TblCustomerLists { get; set; }

    public virtual DbSet<TblItemList> TblItemLists { get; set; }

    public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }

    public virtual DbSet<TblOrderMaster> TblOrderMasters { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCustomerList>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK_SL_tblCustomerList");

            entity.ToTable("tblCustomerList");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CustomerName).HasMaxLength(250);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblItemList>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("tblItemList");

            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemID");
            entity.Property(e => e.InvUnitOfMeasr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ItemName).HasMaxLength(250);
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.HasKey(e => e.RowDetailId);

            entity.ToTable("tblOrderDetail");

            entity.HasIndex(e => new { e.OrderMasterId, e.ItemId }, "UK_tblOrderDetail").IsUnique();

            entity.Property(e => e.RowDetailId)
                .ValueGeneratedNever()
                .HasColumnName("RowDetailID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ItemID");
            entity.Property(e => e.OrderMasterId).HasColumnName("OrderMasterID");

            entity.HasOne(d => d.OrderMaster).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.OrderMasterId)
                .HasConstraintName("FK_tblOrderDetail_tblOrderMaster");
        });

        modelBuilder.Entity<TblOrderMaster>(entity =>
        {
            entity.HasKey(e => e.OrderMasterId);

            entity.ToTable("tblOrderMaster");

            entity.Property(e => e.OrderMasterId)
                .ValueGeneratedNever()
                .HasColumnName("OrderMasterID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CustomerID");
            entity.Property(e => e.DivSubId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Mã đơn vị/chi nhánh")
                .HasColumnName("DivSubID");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
