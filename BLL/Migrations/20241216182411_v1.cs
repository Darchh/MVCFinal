using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPayments_Matches_MatchesId",
                table: "PlayerPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPayments_Players_PlayerId",
                table: "PlayerPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerPayments",
                table: "PlayerPayments");

            migrationBuilder.RenameTable(
                name: "PlayerPayments",
                newName: "Payments");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerPayments_PlayerId",
                table: "Payments",
                newName: "IX_Payments_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerPayments_MatchesId",
                table: "Payments",
                newName: "IX_Payments_MatchesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Matches_MatchesId",
                table: "Payments",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Players_PlayerId",
                table: "Payments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Matches_MatchesId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Players_PlayerId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "PlayerPayments");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_PlayerId",
                table: "PlayerPayments",
                newName: "IX_PlayerPayments_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_MatchesId",
                table: "PlayerPayments",
                newName: "IX_PlayerPayments_MatchesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerPayments",
                table: "PlayerPayments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPayments_Matches_MatchesId",
                table: "PlayerPayments",
                column: "MatchesId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPayments_Players_PlayerId",
                table: "PlayerPayments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
