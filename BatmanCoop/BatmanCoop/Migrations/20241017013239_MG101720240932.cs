using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101720240932 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccountTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemMId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Def_Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Acc_Status = table.Column<bool>(type: "bit", nullable: false),
                    Reg_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Renew = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Expire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Count_Update = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccountTable_MemberTable_MemMId",
                        column: x => x.MemMId,
                        principalTable: "MemberTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountTable_MemMId",
                table: "UserAccountTable",
                column: "MemMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccountTable");
        }
    }
}
