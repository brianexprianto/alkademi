using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ecommerce.WebApp.Datas.Entities;

namespace Ecommerce.WebApp.Datas
{
    public partial class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext()
        {
        }

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Alamat> Alamats { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<KategoriProduk> KategoriProduks { get; set; } = null!;
        public virtual DbSet<Keranjang> Keranjangs { get; set; } = null!;
        public virtual DbSet<Orderr> Orderrs { get; set; } = null!;
        public virtual DbSet<Pembayaran> Pembayarans { get; set; } = null!;
        public virtual DbSet<Pengiriman> Pengirimen { get; set; } = null!;
        public virtual DbSet<Produk> Produks { get; set; } = null!;
        public virtual DbSet<ProdukKategori> ProdukKategoris { get; set; } = null!;
        public virtual DbSet<StatusOrder> StatusOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseMySql("server=localhost;user=root;database=ecommerce", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.8-mariadb"));
//             }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PRIMARY");

                entity.ToTable("admin");

                entity.Property(e => e.IdAdmin)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(100)
                    .HasColumnName("nama_admin");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .HasColumnName("no_hp");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Alamat>(entity =>
            {
                entity.HasKey(e => e.IdAlamat)
                    .HasName("PRIMARY");

                entity.ToTable("alamat");

                entity.HasIndex(e => e.IdCustomer, "fk_id_customerrr");

                entity.Property(e => e.IdAlamat)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id_alamat");

                entity.Property(e => e.DetailAlamat)
                    .HasMaxLength(255)
                    .HasColumnName("detail_alamat");

                entity.Property(e => e.IdCustomer)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_customer");

                entity.Property(e => e.KabKota)
                    .HasMaxLength(255)
                    .HasColumnName("kab_kota");

                entity.Property(e => e.Kec)
                    .HasMaxLength(255)
                    .HasColumnName("kec");

                entity.Property(e => e.Kel)
                    .HasMaxLength(255)
                    .HasColumnName("kel");

                entity.Property(e => e.KodePos)
                    .HasMaxLength(10)
                    .HasColumnName("kode_pos");

                entity.Property(e => e.Prov)
                    .HasMaxLength(255)
                    .HasColumnName("prov");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Alamats)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("fk_id_customerrr");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PRIMARY");

                entity.ToTable("customer");

                entity.Property(e => e.IdCustomer)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_customer");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(255)
                    .HasColumnName("nama_customer");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(13)
                    .HasColumnName("no_hp");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(255)
                    .HasColumnName("profile_picture");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<KategoriProduk>(entity =>
            {
                entity.HasKey(e => e.IdKategori)
                    .HasName("PRIMARY");

                entity.ToTable("kategori_produk");

                entity.Property(e => e.IdKategori)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_kategori");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(1000)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.Icon)
                    .HasMaxLength(255)
                    .HasColumnName("icon");

                entity.Property(e => e.NamaKategori)
                    .HasMaxLength(255)
                    .HasColumnName("nama_kategori");
            });

            modelBuilder.Entity<Keranjang>(entity =>
            {
                entity.HasKey(e => e.IdKeranjang)
                    .HasName("PRIMARY");

                entity.ToTable("keranjang");

                entity.HasIndex(e => e.IdCustomer, "fk_id_customer");

                entity.Property(e => e.IdKeranjang)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_keranjang");

                entity.Property(e => e.IdCustomer)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_customer");

                entity.Property(e => e.JlhBarang)
                    .HasColumnType("int(11)")
                    .HasColumnName("jlh_barang");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(10)
                    .HasColumnName("subtotal");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Keranjangs)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_customer");
            });

            modelBuilder.Entity<Orderr>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PRIMARY");

                entity.ToTable("orderr");

                entity.HasIndex(e => e.IdAlamat, "fk_id_alamat");

                entity.HasIndex(e => e.IdCustomer, "fk_id_customerr");

                entity.HasIndex(e => e.IdKeranjang, "fk_id_kerangjang");

                entity.Property(e => e.IdOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_order");

                entity.Property(e => e.IdAlamat)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_alamat");

                entity.Property(e => e.IdCustomer)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_customer");

                entity.Property(e => e.IdKeranjang)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_keranjang");

                entity.Property(e => e.JlhBayar)
                    .HasPrecision(10, 2)
                    .HasColumnName("jlh_bayar");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.TglTransaksi)
                    .HasColumnType("int(11)")
                    .HasColumnName("tgl_transaksi");

                entity.HasOne(d => d.IdAlamatNavigation)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.IdAlamat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_alamat");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_customerr");

                entity.HasOne(d => d.IdKeranjangNavigation)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.IdKeranjang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_kerangjang");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran)
                    .HasName("PRIMARY");

                entity.ToTable("pembayaran");

                entity.HasIndex(e => e.IdCustomer, "fk_id_customerrrr");

                entity.HasIndex(e => e.IdOrder, "fk_id_order");

                entity.Property(e => e.IdPembayaran)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_pembayaran");

                entity.Property(e => e.IdCustomer)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_customer");

                entity.Property(e => e.IdOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_order");

                entity.Property(e => e.MetodePembayaran)
                    .HasMaxLength(255)
                    .HasColumnName("metode_pembayaran");

                entity.Property(e => e.Pajak)
                    .HasPrecision(10, 2)
                    .HasColumnName("pajak");

                entity.Property(e => e.TglBayar).HasColumnName("tgl_bayar");

                entity.Property(e => e.TotalBayar)
                    .HasPrecision(10, 2)
                    .HasColumnName("total_bayar");

                entity.Property(e => e.Tujuan)
                    .HasMaxLength(255)
                    .HasColumnName("tujuan");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Pembayarans)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_customerrrr");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Pembayarans)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_order");
            });

            modelBuilder.Entity<Pengiriman>(entity =>
            {
                entity.HasKey(e => e.IdPengiriman)
                    .HasName("PRIMARY");

                entity.ToTable("pengiriman");

                entity.HasIndex(e => e.IdAlamat, "fk_id_alamatt");

                entity.HasIndex(e => e.IdOrder, "fk_id_orderrr");

                entity.Property(e => e.IdPengiriman)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_pengiriman");

                entity.Property(e => e.IdAlamat)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_alamat");

                entity.Property(e => e.IdOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_order");

                entity.Property(e => e.Kurir)
                    .HasMaxLength(255)
                    .HasColumnName("kurir");

                entity.Property(e => e.Ongkir)
                    .HasPrecision(10, 2)
                    .HasColumnName("ongkir");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.IdAlamatNavigation)
                    .WithMany(p => p.Pengirimen)
                    .HasForeignKey(d => d.IdAlamat)
                    .HasConstraintName("fk_id_alamatt");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Pengirimen)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("fk_id_orderrr");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.IdProduk)
                    .HasName("PRIMARY");

                entity.ToTable("produk");

                entity.Property(e => e.IdProduk)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_produk");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(255)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.Gambar)
                    .HasMaxLength(255)
                    .HasColumnName("gambar");

                entity.Property(e => e.Harga)
                    .HasPrecision(10, 2)
                    .HasColumnName("harga");

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(255)
                    .HasColumnName("nama_produk");

                entity.Property(e => e.Stok)
                    .HasColumnType("int(11)")
                    .HasColumnName("stok");
            });

            modelBuilder.Entity<ProdukKategori>(entity =>
            {
                entity.HasKey(e => e.IdProdukKategori)
                    .HasName("PRIMARY");

                entity.ToTable("produk_kategori");

                entity.HasIndex(e => e.IdKategori, "fk_id_kategori");

                entity.HasIndex(e => e.IdProduk, "fk_id_produk");

                entity.Property(e => e.IdProdukKategori)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_produk_kategori");

                entity.Property(e => e.IdKategori)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_kategori");

                entity.Property(e => e.IdProduk)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_produk");

                entity.HasOne(d => d.IdKategoriNavigation)
                    .WithMany(p => p.ProdukKategoris)
                    .HasForeignKey(d => d.IdKategori)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_kategori");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.ProdukKategoris)
                    .HasForeignKey(d => d.IdProduk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_produk");
            });

            modelBuilder.Entity<StatusOrder>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PRIMARY");

                entity.ToTable("status_order");

                entity.Property(e => e.IdStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_status");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(255)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.Nama)
                    .HasMaxLength(255)
                    .HasColumnName("nama");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
