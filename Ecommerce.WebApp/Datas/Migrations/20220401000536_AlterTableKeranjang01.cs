using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.WebApp.Datas.Migrations
{
    public partial class AlterTableKeranjang01 : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "IdProduk",
                table: "keranjang",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduk",
                table: "keranjang");

            migrationBuilder.AlterColumn<decimal>(
                name: "subtotal",
                table: "keranjang",
                type: "decimal(10,30)",
                precision: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10);
        }
    }
}
