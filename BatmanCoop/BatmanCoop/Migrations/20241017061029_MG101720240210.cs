using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101720240210 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserAccountTable");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserAccountTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "UserAccountTable",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserAccountTable",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
