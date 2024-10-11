using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101020240336 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reference_Code",
                table: "BuyerDetailsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference_Code",
                table: "BuyerDetailsTable");
        }
    }
}
