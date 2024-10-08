using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG1008240210 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemMId = table.Column<int>(type: "int", nullable: false),
                    Share_Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Share_Points = table.Column<int>(type: "int", nullable: false),
                    Points_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerTable_MemberTable_MemMId",
                        column: x => x.MemMId,
                        principalTable: "MemberTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerTable_MemMId",
                table: "BuyerTable",
                column: "MemMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerTable");
        }
    }
}
