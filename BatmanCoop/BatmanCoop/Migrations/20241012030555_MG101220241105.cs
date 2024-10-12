using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101220241105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyMId",
                table: "BuyerDetailsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerDetailsTable_BuyMId",
                table: "BuyerDetailsTable",
                column: "BuyMId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerDetailsTable_BuyerTable_BuyMId",
                table: "BuyerDetailsTable",
                column: "BuyMId",
                principalTable: "BuyerTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerDetailsTable_BuyerTable_BuyMId",
                table: "BuyerDetailsTable");

            migrationBuilder.DropIndex(
                name: "IX_BuyerDetailsTable_BuyMId",
                table: "BuyerDetailsTable");

            migrationBuilder.DropColumn(
                name: "BuyMId",
                table: "BuyerDetailsTable");
        }
    }
}
