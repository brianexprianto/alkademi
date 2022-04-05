using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.WebApp.Datas.Migrations
{
    public partial class AddTableDetailOrderr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.AlterColumn<decimal>(
                name: "subtotal",
                table: "keranjang",
                type: "decimal(10)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10);

            // migrationBuilder.AddColumn<int>(
            //     name: "IdProdukNavigationIdProduk",
            //     table: "keranjang",
            //     type: "int(11)",
            //     nullable: false,
            //     defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "detail_order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_order = table.Column<int>(type: "int(11)", nullable: false),
                    id_produk = table.Column<int>(type: "int", nullable: false),
                    harga = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false),
                    jlh_barang = table.Column<int>(type: "int", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_order", x => x.id);
                    table.ForeignKey(
                        name: "detail_order_FK_1",
                        column: x => x.id_order,
                        principalTable: "orderr",
                        principalColumn: "id_order");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_keranjang_IdProdukNavigationIdProduk",
                table: "keranjang",
                column: "IdProdukNavigationIdProduk");

            migrationBuilder.CreateIndex(
                name: "detail_order_FK_1",
                table: "detail_order",
                column: "id_order");

            migrationBuilder.AddForeignKey(
                name: "FK_keranjang_produk_IdProdukNavigationIdProduk",
                table: "keranjang",
                column: "IdProdukNavigationIdProduk",
                principalTable: "produk",
                principalColumn: "id_produk",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_keranjang_produk_IdProdukNavigationIdProduk",
                table: "keranjang");

            migrationBuilder.DropTable(
                name: "detail_order");

            migrationBuilder.DropIndex(
                name: "IX_keranjang_IdProdukNavigationIdProduk",
                table: "keranjang");

            migrationBuilder.DropColumn(
                name: "IdProdukNavigationIdProduk",
                table: "keranjang");

            migrationBuilder.AddColumn<int>(
                name: "id_keranjang",
                table: "orderr",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "subtotal",
                table: "keranjang",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);

            migrationBuilder.CreateIndex(
                name: "fk_id_kerangjang",
                table: "orderr",
                column: "id_keranjang");

            migrationBuilder.AddForeignKey(
                name: "fk_id_kerangjang",
                table: "orderr",
                column: "id_keranjang",
                principalTable: "keranjang",
                principalColumn: "id_keranjang");
        }
    }
}
