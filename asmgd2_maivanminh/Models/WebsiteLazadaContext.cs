using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace asmgd2_maivanminh.Models;

public partial class WebsiteLazadaContext : DbContext
{
    public WebsiteLazadaContext()
    {
    }

    public WebsiteLazadaContext(DbContextOptions<WebsiteLazadaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCart> TbCarts { get; set; }

    public virtual DbSet<TbCartDetail> TbCartDetails { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbStaft> TbStafts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-CKN1UE62\\MAIVANMINH;Initial Catalog=Website_lazada;Integrated Security=True;Trust Server Certificate=True", x => x.UseNetTopologySuite());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Tb_Carts__D6AB47595BEAAB7C");

            entity.ToTable("Tb_Carts");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("Cart_Id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
        });

        modelBuilder.Entity<TbCartDetail>(entity =>
        {
            entity.HasKey(e => e.CartDetailId).HasName("PK__Tb_Cart___85F0041BB0BFEE06");

            entity.ToTable("Tb_Cart_Detail");

            entity.Property(e => e.CartDetailId)
                .ValueGeneratedNever()
                .HasColumnName("CartDetail_Id");
            entity.Property(e => e.CartId).HasColumnName("Cart_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");

            entity.HasOne(d => d.Cart).WithMany(p => p.TbCartDetails)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__Tb_Cart_D__Cart___7A672E12");

            entity.HasOne(d => d.Product).WithMany(p => p.TbCartDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Tb_Cart_D__Produ__7B5B524B");
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Tb_Categ__6DB38D6E6F71C561");

            entity.ToTable("Tb_Categories");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("Category_Id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("Category_Name");
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Tb_Custo__1788CC4CC7662789");

            entity.ToTable("Tb_Customers");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Addresz).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Pass).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Tb_Produ__9834FBBA6C75567C");

            entity.ToTable("Tb_Products");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("Product_Id");
            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.Descriptions).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("Product_Name");

            entity.HasOne(d => d.Category).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Tb_Produc__Categ__398D8EEE");
        });

        modelBuilder.Entity<TbStaft>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_staft__3213E83FF3D74DF8");

            entity.ToTable("Tb_staft");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Pass)
                .HasMaxLength(20)
                .HasColumnName("pass");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
