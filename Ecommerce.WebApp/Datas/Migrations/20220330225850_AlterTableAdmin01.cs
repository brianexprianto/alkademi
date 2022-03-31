﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.WebApp.Datas.Migrations
{
    public partial class AlterTableAdmin01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id_admin = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama_admin = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    no_hp = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_admin);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id_customer = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama_customer = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    no_hp = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    profile_picture = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_customer);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "kategori_produk",
                columns: table => new
                {
                    id_kategori = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama_kategori = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deskripsi = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_kategori);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "produk",
                columns: table => new
                {
                    id_produk = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama_produk = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deskripsi = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    harga = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    stok = table.Column<int>(type: "int(11)", nullable: false),
                    gambar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_produk);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "status_order",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nama = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deskripsi = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_status);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "alamat",
                columns: table => new
                {
                    id_alamat = table.Column<int>(type: "int(11)", nullable: false),
                    id_customer = table.Column<int>(type: "int(11)", nullable: false),
                    kec = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    kel = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    kab_kota = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    prov = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    detail_alamat = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    kode_pos = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_alamat);
                    table.ForeignKey(
                        name: "fk_id_customerrr",
                        column: x => x.id_customer,
                        principalTable: "customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "keranjang",
                columns: table => new
                {
                    id_keranjang = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_customer = table.Column<int>(type: "int(11)", nullable: false),
                    jlh_barang = table.Column<int>(type: "int(11)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_keranjang);
                    table.ForeignKey(
                        name: "fk_id_customer",
                        column: x => x.id_customer,
                        principalTable: "customer",
                        principalColumn: "id_customer");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "produk_kategori",
                columns: table => new
                {
                    id_produk_kategori = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_produk = table.Column<int>(type: "int(11)", nullable: false),
                    id_kategori = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_produk_kategori);
                    table.ForeignKey(
                        name: "fk_id_kategori",
                        column: x => x.id_kategori,
                        principalTable: "kategori_produk",
                        principalColumn: "id_kategori");
                    table.ForeignKey(
                        name: "fk_id_produk",
                        column: x => x.id_produk,
                        principalTable: "produk",
                        principalColumn: "id_produk");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "orderr",
                columns: table => new
                {
                    id_order = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_keranjang = table.Column<int>(type: "int(11)", nullable: false),
                    tgl_transaksi = table.Column<int>(type: "int(11)", nullable: false),
                    jlh_bayar = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    id_alamat = table.Column<int>(type: "int(11)", nullable: false),
                    id_customer = table.Column<int>(type: "int(11)", nullable: false),
                    status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    notes = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_order);
                    table.ForeignKey(
                        name: "fk_id_alamat",
                        column: x => x.id_alamat,
                        principalTable: "alamat",
                        principalColumn: "id_alamat");
                    table.ForeignKey(
                        name: "fk_id_customerr",
                        column: x => x.id_customer,
                        principalTable: "customer",
                        principalColumn: "id_customer");
                    table.ForeignKey(
                        name: "fk_id_kerangjang",
                        column: x => x.id_keranjang,
                        principalTable: "keranjang",
                        principalColumn: "id_keranjang");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "pembayaran",
                columns: table => new
                {
                    id_pembayaran = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_order = table.Column<int>(type: "int(11)", nullable: false),
                    id_customer = table.Column<int>(type: "int(11)", nullable: false),
                    metode_pembayaran = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_bayar = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tgl_bayar = table.Column<DateOnly>(type: "date", nullable: false),
                    pajak = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tujuan = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_pembayaran);
                    table.ForeignKey(
                        name: "fk_id_customerrrr",
                        column: x => x.id_customer,
                        principalTable: "customer",
                        principalColumn: "id_customer");
                    table.ForeignKey(
                        name: "fk_id_order",
                        column: x => x.id_order,
                        principalTable: "orderr",
                        principalColumn: "id_order");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "pengiriman",
                columns: table => new
                {
                    id_pengiriman = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_order = table.Column<int>(type: "int(11)", nullable: false),
                    kurir = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ongkir = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    id_alamat = table.Column<int>(type: "int(11)", nullable: false),
                    status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_pengiriman);
                    table.ForeignKey(
                        name: "fk_id_alamatt",
                        column: x => x.id_alamat,
                        principalTable: "alamat",
                        principalColumn: "id_alamat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_id_orderrr",
                        column: x => x.id_order,
                        principalTable: "orderr",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_id_customerrr",
                table: "alamat",
                column: "id_customer");

            migrationBuilder.CreateIndex(
                name: "fk_id_customer",
                table: "keranjang",
                column: "id_customer");

            migrationBuilder.CreateIndex(
                name: "fk_id_alamat",
                table: "orderr",
                column: "id_alamat");

            migrationBuilder.CreateIndex(
                name: "fk_id_customerr",
                table: "orderr",
                column: "id_customer");

            migrationBuilder.CreateIndex(
                name: "fk_id_kerangjang",
                table: "orderr",
                column: "id_keranjang");

            migrationBuilder.CreateIndex(
                name: "fk_id_customerrrr",
                table: "pembayaran",
                column: "id_customer");

            migrationBuilder.CreateIndex(
                name: "fk_id_order",
                table: "pembayaran",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "fk_id_alamatt",
                table: "pengiriman",
                column: "id_alamat");

            migrationBuilder.CreateIndex(
                name: "fk_id_orderrr",
                table: "pengiriman",
                column: "id_order");

            migrationBuilder.CreateIndex(
                name: "fk_id_kategori",
                table: "produk_kategori",
                column: "id_kategori");

            migrationBuilder.CreateIndex(
                name: "fk_id_produk",
                table: "produk_kategori",
                column: "id_produk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "pembayaran");

            migrationBuilder.DropTable(
                name: "pengiriman");

            migrationBuilder.DropTable(
                name: "produk_kategori");

            migrationBuilder.DropTable(
                name: "status_order");

            migrationBuilder.DropTable(
                name: "orderr");

            migrationBuilder.DropTable(
                name: "kategori_produk");

            migrationBuilder.DropTable(
                name: "produk");

            migrationBuilder.DropTable(
                name: "alamat");

            migrationBuilder.DropTable(
                name: "keranjang");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
