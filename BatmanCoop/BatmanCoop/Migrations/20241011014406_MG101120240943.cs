using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101120240943 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAdd",
                table: "MemberTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAdd",
                table: "MemberTable");
        }
    }
}
