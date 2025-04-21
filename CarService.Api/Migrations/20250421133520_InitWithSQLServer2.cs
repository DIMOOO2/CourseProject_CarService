using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarService.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitWithSQLServer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoParts_Warehouses_WarehouseId",
                table: "AutoParts");

            migrationBuilder.AlterColumn<long>(
                name: "WarehouseId",
                table: "AutoParts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoParts_Warehouses_WarehouseId",
                table: "AutoParts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoParts_Warehouses_WarehouseId",
                table: "AutoParts");

            migrationBuilder.AlterColumn<long>(
                name: "WarehouseId",
                table: "AutoParts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoParts_Warehouses_WarehouseId",
                table: "AutoParts",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
