using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MGInitials101024 : Migration
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
                    Buy_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Share_Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valid_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Share_Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivilStatusTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatusTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemAttachTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Contenttype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Img_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Member_No = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemAttachTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CivilStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferralId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferralName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyerDetailsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buy_Count = table.Column<int>(type: "int", nullable: false),
                    MemMId = table.Column<int>(type: "int", nullable: false),
                    Share_Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Share_Points = table.Column<int>(type: "int", nullable: false),
                    Points_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approve_Status = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Buy_Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerDetailsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerDetailsTable_MemberTable_MemMId",
                        column: x => x.MemMId,
                        principalTable: "MemberTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransLogsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trans_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemMId = table.Column<int>(type: "int", nullable: false),
                    BuyMId = table.Column<int>(type: "int", nullable: false),
                    Buy_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Payment_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trans_Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransLogsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransLogsTable_BuyerTable_BuyMId",
                        column: x => x.BuyMId,
                        principalTable: "BuyerTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransLogsTable_MemberTable_MemMId",
                        column: x => x.MemMId,
                        principalTable: "MemberTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerDetailsTable_MemMId",
                table: "BuyerDetailsTable",
                column: "MemMId");

            migrationBuilder.CreateIndex(
                name: "IX_TransLogsTable_BuyMId",
                table: "TransLogsTable",
                column: "BuyMId");

            migrationBuilder.CreateIndex(
                name: "IX_TransLogsTable_MemMId",
                table: "TransLogsTable",
                column: "MemMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerDetailsTable");

            migrationBuilder.DropTable(
                name: "CivilStatusTable");

            migrationBuilder.DropTable(
                name: "MemAttachTable");

            migrationBuilder.DropTable(
                name: "TransLogsTable");

            migrationBuilder.DropTable(
                name: "BuyerTable");

            migrationBuilder.DropTable(
                name: "MemberTable");
        }
    }
}
