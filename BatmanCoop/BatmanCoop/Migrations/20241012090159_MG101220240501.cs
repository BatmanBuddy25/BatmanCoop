using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatmanCoop.Migrations
{
    /// <inheritdoc />
    public partial class MG101220240501 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTable_PaymentTypeM_PayTypeMId",
                table: "MemberTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypeM",
                table: "PaymentTypeM");

            migrationBuilder.RenameTable(
                name: "PaymentTypeM",
                newName: "PaymentTypeTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypeTable",
                table: "PaymentTypeTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTable_PaymentTypeTable_PayTypeMId",
                table: "MemberTable",
                column: "PayTypeMId",
                principalTable: "PaymentTypeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTable_PaymentTypeTable_PayTypeMId",
                table: "MemberTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentTypeTable",
                table: "PaymentTypeTable");

            migrationBuilder.RenameTable(
                name: "PaymentTypeTable",
                newName: "PaymentTypeM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentTypeM",
                table: "PaymentTypeM",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTable_PaymentTypeM_PayTypeMId",
                table: "MemberTable",
                column: "PayTypeMId",
                principalTable: "PaymentTypeM",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
