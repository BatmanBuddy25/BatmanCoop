using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101720241100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Account_Role",
                table: "UserAccountTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account_Role",
                table: "UserAccountTable");
        }
    }
}
