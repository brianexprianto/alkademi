﻿// <auto-generated />
using System;
using Ecommerce.WebApp.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.WebApp.Datas.Migrations
{
    [DbContext(typeof(EcommerceDbContext))]
    partial class EcommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Admin", b =>
                {
                    b.Property<int>("IdAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_admin");

                    b.Property<string>("NamaAdmin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nama_admin");

                    b.Property<string>("NoHp")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("no_hp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("username");

                    b.HasKey("IdAdmin")
                        .HasName("PRIMARY");

                    b.ToTable("admin", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Alamat", b =>
                {
                    b.Property<int>("IdAlamat")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_alamat");

                    b.Property<string>("DetailAlamat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("detail_alamat");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_customer");

                    b.Property<string>("KabKota")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("kab_kota");

                    b.Property<string>("Kec")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("kec");

                    b.Property<string>("Kel")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("kel");

                    b.Property<string>("KodePos")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("kode_pos");

                    b.Property<string>("Prov")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("prov");

                    b.HasKey("IdAlamat")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCustomer" }, "fk_id_customerrr");

                    b.ToTable("alamat", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_customer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("NamaCustomer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nama_customer");

                    b.Property<string>("NoHp")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)")
                        .HasColumnName("no_hp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("profile_picture");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("IdCustomer")
                        .HasName("PRIMARY");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.DetailOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal>("Harga")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("harga");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_order");

                    b.Property<int>("IdProduk")
                        .HasColumnType("int")
                        .HasColumnName("id_produk");

                    b.Property<int>("JlhBarang")
                        .HasColumnType("int")
                        .HasColumnName("jlh_barang");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("subtotal");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdOrder" }, "detail_order_FK_1");

                    b.ToTable("detail_order", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.KategoriProduk", b =>
                {
                    b.Property<int>("IdKategori")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_kategori");

                    b.Property<string>("Deskripsi")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("deskripsi");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("icon");

                    b.Property<string>("NamaKategori")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nama_kategori");

                    b.HasKey("IdKategori")
                        .HasName("PRIMARY");

                    b.ToTable("kategori_produk", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Keranjang", b =>
                {
                    b.Property<int>("IdKeranjang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_keranjang");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_customer");

                    b.Property<int>("IdProduk")
                        .HasColumnType("int");

                    b.Property<int>("IdProdukNavigationIdProduk")
                        .HasColumnType("int(11)");

                    b.Property<int>("JlhBarang")
                        .HasColumnType("int(11)")
                        .HasColumnName("jlh_barang");

                    b.Property<decimal>("Subtotal")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("subtotal");

                    b.HasKey("IdKeranjang")
                        .HasName("PRIMARY");

                    b.HasIndex("IdProdukNavigationIdProduk");

                    b.HasIndex(new[] { "IdCustomer" }, "fk_id_customer");

                    b.ToTable("keranjang", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Orderr", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_order");

                    b.Property<int>("IdAlamat")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_alamat");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_customer");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_status");

                    b.Property<decimal>("JlhBayar")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("jlh_bayar");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("notes");

                    b.Property<DateTime>("TglTransaksi")
                        .HasColumnType("Date")
                        .HasColumnName("tgl_transaksi");

                    b.HasKey("IdOrder")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdAlamat" }, "fk_id_alamat");

                    b.HasIndex(new[] { "IdCustomer" }, "fk_id_customerr");

                    b.ToTable("orderr", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Pembayaran", b =>
                {
                    b.Property<int>("IdPembayaran")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_pembayaran");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_customer");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_order");

                    b.Property<string>("MetodePembayaran")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("metode_pembayaran");

                    b.Property<decimal>("Pajak")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("pajak");

                    b.Property<DateOnly>("TglBayar")
                        .HasColumnType("date")
                        .HasColumnName("tgl_bayar");

                    b.Property<decimal>("TotalBayar")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("total_bayar");

                    b.Property<string>("Tujuan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tujuan");

                    b.HasKey("IdPembayaran")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCustomer" }, "fk_id_customerrrr");

                    b.HasIndex(new[] { "IdOrder" }, "fk_id_order");

                    b.ToTable("pembayaran", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Pengiriman", b =>
                {
                    b.Property<int>("IdPengiriman")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_pengiriman");

                    b.Property<int>("IdAlamat")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_alamat");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_order");

                    b.Property<string>("Kurir")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("kurir");

                    b.Property<decimal>("Ongkir")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("ongkir");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.HasKey("IdPengiriman")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdAlamat" }, "fk_id_alamatt");

                    b.HasIndex(new[] { "IdOrder" }, "fk_id_orderrr");

                    b.ToTable("pengiriman", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Produk", b =>
                {
                    b.Property<int>("IdProduk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_produk");

                    b.Property<string>("Deskripsi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("deskripsi");

                    b.Property<string>("Gambar")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("gambar");

                    b.Property<decimal>("Harga")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("harga");

                    b.Property<string>("NamaProduk")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nama_produk");

                    b.Property<int>("Stok")
                        .HasColumnType("int(11)")
                        .HasColumnName("stok");

                    b.HasKey("IdProduk")
                        .HasName("PRIMARY");

                    b.ToTable("produk", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.ProdukKategori", b =>
                {
                    b.Property<int>("IdProdukKategori")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_produk_kategori");

                    b.Property<int>("IdKategori")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_kategori");

                    b.Property<int>("IdProduk")
                        .HasColumnType("int(11)")
                        .HasColumnName("id_produk");

                    b.HasKey("IdProdukKategori")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdKategori" }, "fk_id_kategori");

                    b.HasIndex(new[] { "IdProduk" }, "fk_id_produk");

                    b.ToTable("produk_kategori", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.StatusOrder", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id_status");

                    b.Property<string>("Deskripsi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("deskripsi");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nama");

                    b.HasKey("IdStatus")
                        .HasName("PRIMARY");

                    b.ToTable("status_order", (string)null);
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Alamat", b =>
                {
                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Alamats")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_id_customerrr");

                    b.Navigation("IdCustomerNavigation");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.DetailOrder", b =>
                {
                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Orderr", "Orderr")
                        .WithMany("DetailOrders")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("detail_order_FK_1");

                    b.Navigation("Orderr");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Keranjang", b =>
                {
                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Keranjangs")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("fk_id_customer");

                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Produk", "IdProdukNavigation")
                        .WithMany()
                        .HasForeignKey("IdProdukNavigationIdProduk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCustomerNavigation");

                    b.Navigation("IdProdukNavigation");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Orderr", b =>
                {
                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Alamat", "IdAlamatNavigation")
                        .WithMany("Orderrs")
                        .HasForeignKey("IdAlamat")
                        .IsRequired()
                        .HasConstraintName("fk_id_alamat");

                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Orderrs")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("fk_id_customerr");

                    b.Navigation("IdAlamatNavigation");

                    b.Navigation("IdCustomerNavigation");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Pembayaran", b =>
                {
                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Pembayarans")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("fk_id_customerrrr");

                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Orderr", "IdOrderNavigation")
                        .WithMany("Pembayarans")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("fk_id_order");

                    b.Navigation("IdCustomerNavigation");

                    b.Navigation("IdOrderNavigation");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Pengiriman", b =>
                {
                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Alamat", "IdAlamatNavigation")
                        .WithMany("Pengirimen")
                        .HasForeignKey("IdAlamat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_id_alamatt");

                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Orderr", "IdOrderNavigation")
                        .WithMany("Pengirimen")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_id_orderrr");

                    b.Navigation("IdAlamatNavigation");

                    b.Navigation("IdOrderNavigation");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.ProdukKategori", b =>
                {
                    b.HasOne("Ecommerce.WebApp.Datas.Entities.KategoriProduk", "IdKategoriNavigation")
                        .WithMany("ProdukKategoris")
                        .HasForeignKey("IdKategori")
                        .IsRequired()
                        .HasConstraintName("fk_id_kategori");

                    b.HasOne("Ecommerce.WebApp.Datas.Entities.Produk", "IdProdukNavigation")
                        .WithMany("ProdukKategoris")
                        .HasForeignKey("IdProduk")
                        .IsRequired()
                        .HasConstraintName("fk_id_produk");

                    b.Navigation("IdKategoriNavigation");

                    b.Navigation("IdProdukNavigation");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Alamat", b =>
                {
                    b.Navigation("Orderrs");

                    b.Navigation("Pengirimen");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Customer", b =>
                {
                    b.Navigation("Alamats");

                    b.Navigation("Keranjangs");

                    b.Navigation("Orderrs");

                    b.Navigation("Pembayarans");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.KategoriProduk", b =>
                {
                    b.Navigation("ProdukKategoris");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Orderr", b =>
                {
                    b.Navigation("DetailOrders");

                    b.Navigation("Pembayarans");

                    b.Navigation("Pengirimen");
                });

            modelBuilder.Entity("Ecommerce.WebApp.Datas.Entities.Produk", b =>
                {
                    b.Navigation("ProdukKategoris");
                });
#pragma warning restore 612, 618
        }
    }
}
