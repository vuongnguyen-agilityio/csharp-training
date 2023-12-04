using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseHistoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseHistories",
                table: "PurchaseHistories");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PurchaseHistoryItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseHistories",
                table: "PurchaseHistories",
                columns: new[] { "Id", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistoryItems_PurchaseHistoryId_UserId",
                table: "PurchaseHistoryItems",
                columns: new[] { "PurchaseHistoryId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistoryItems_PurchaseHistories_PurchaseHistoryId_Us~",
                table: "PurchaseHistoryItems",
                columns: new[] { "PurchaseHistoryId", "UserId" },
                principalTable: "PurchaseHistories",
                principalColumns: new[] { "Id", "UserId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistoryItems_PurchaseHistories_PurchaseHistoryId_Us~",
                table: "PurchaseHistoryItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseHistoryItems_PurchaseHistoryId_UserId",
                table: "PurchaseHistoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseHistories",
                table: "PurchaseHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PurchaseHistoryItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseHistories",
                table: "PurchaseHistories",
                column: "Id");
        }
    }
}
