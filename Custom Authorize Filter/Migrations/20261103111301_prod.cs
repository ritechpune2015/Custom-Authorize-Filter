using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Custom_Authorize_Filter.Migrations
{
    /// <inheritdoc />
    public partial class prod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyID1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyID1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyID1",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyID",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyID",
                table: "Products",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyID",
                table: "Products",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyID",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyID",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CompanyID1",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyID1",
                table: "Products",
                column: "CompanyID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyID1",
                table: "Products",
                column: "CompanyID1",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
