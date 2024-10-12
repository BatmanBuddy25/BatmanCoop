using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101220240500 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayTypeMId",
                table: "MemberTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentTypeM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberTable_PayTypeMId",
                table: "MemberTable",
                column: "PayTypeMId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTable_PaymentTypeM_PayTypeMId",
                table: "MemberTable",
                column: "PayTypeMId",
                principalTable: "PaymentTypeM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTable_PaymentTypeM_PayTypeMId",
                table: "MemberTable");

            migrationBuilder.DropTable(
                name: "PaymentTypeM");

            migrationBuilder.DropIndex(
                name: "IX_MemberTable_PayTypeMId",
                table: "MemberTable");

            migrationBuilder.DropColumn(
                name: "PayTypeMId",
                table: "MemberTable");
        }
    }
}
