using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace catologue_ef.newEntities;

public partial class CatalogueDbContext : DbContext
{
    public CatalogueDbContext()
    {
    }

    public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSpec> ProductSpecs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=OCTOTHORPE;Database=catalogue_db;Trusted_Connection=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Category");

            entity.Property(e => e.CategoryId)
                .IsUnicode(false)
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryDescription).HasColumnName("category_description");
            entity.Property(e => e.CategoryName)
                .IsUnicode(false)
                .HasColumnName("category_name");
            entity.Property(e => e.CategoryProductCount).HasColumnName("category_product_count");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId)
                .IsUnicode(false)
                .HasColumnName("product_id");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("category_id");
            entity.Property(e => e.ProductBrand)
                .IsUnicode(false)
                .HasColumnName("product_brand");
            entity.Property(e => e.ProductName)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products");
        });

        modelBuilder.Entity<ProductSpec>(entity =>
        {
            entity.HasKey(e => e.SpecId);

            entity.Property(e => e.SpecId).HasColumnName("spec_id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("product_id");
            entity.Property(e => e.SpecName)
                .IsUnicode(false)
                .HasColumnName("spec_name");
            entity.Property(e => e.Value)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSpecs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductSpecs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
