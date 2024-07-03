using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace messenger.Migrations
{
    /// <inheritdoc />
    public partial class addOneToManyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReplyOF",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PVs_personOneID",
                table: "PVs",
                column: "personOneID");

            migrationBuilder.CreateIndex(
                name: "IX_PVs_personTwoID",
                table: "PVs",
                column: "personTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AccountID",
                table: "Notifications",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_senderID",
                table: "Messages",
                column: "senderID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_userID",
                table: "Accounts",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_userID",
                table: "Accounts",
                column: "userID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_senderID",
                table: "Messages",
                column: "senderID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Accounts_AccountID",
                table: "Notifications",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PVs_Accounts_personOneID",
                table: "PVs",
                column: "personOneID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PVs_Accounts_personTwoID",
                table: "PVs",
                column: "personTwoID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_userID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_senderID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Accounts_AccountID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PVs_Accounts_personOneID",
                table: "PVs");

            migrationBuilder.DropForeignKey(
                name: "FK_PVs_Accounts_personTwoID",
                table: "PVs");

            migrationBuilder.DropIndex(
                name: "IX_PVs_personOneID",
                table: "PVs");

            migrationBuilder.DropIndex(
                name: "IX_PVs_personTwoID",
                table: "PVs");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AccountID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Messages_senderID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_userID",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "ReplyOF",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
