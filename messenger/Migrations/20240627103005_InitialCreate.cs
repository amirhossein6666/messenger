using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace messenger.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accountID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false),
                    isOnline = table.Column<bool>(type: "bit", nullable: true),
                    lastSeen = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    channelID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messagesNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messagesNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ChatType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatID = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    receiveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountContacts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false),
                    closeFriend = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountContacts", x => new { x.AccountID, x.ContactID });
                    table.ForeignKey(
                        name: "FK_AccountContacts_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountContacts_Accounts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    personOneID = table.Column<int>(type: "int", nullable: false),
                    personTwoID = table.Column<int>(type: "int", nullable: false),
                    messagesNumber = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PVs_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AccountChannel",
                columns: table => new
                {
                    ChannelsID = table.Column<int>(type: "int", nullable: false),
                    membersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChannel", x => new { x.ChannelsID, x.membersID });
                    table.ForeignKey(
                        name: "FK_AccountChannel_Accounts_membersID",
                        column: x => x.membersID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountChannel_Channels_ChannelsID",
                        column: x => x.ChannelsID,
                        principalTable: "Channels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountChannels",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ChannelID = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChannels", x => new { x.AccountID, x.ChannelID });
                    table.ForeignKey(
                        name: "FK_AccountChannels_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountChannels_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountGroup",
                columns: table => new
                {
                    GroupsID = table.Column<int>(type: "int", nullable: false),
                    membersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroup", x => new { x.GroupsID, x.membersID });
                    table.ForeignKey(
                        name: "FK_AccountGroup_Accounts_membersID",
                        column: x => x.membersID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountGroup_Groups_GroupsID",
                        column: x => x.GroupsID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountGroups",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroups", x => new { x.AccountID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_AccountGroups_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountGroups_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    senderID = table.Column<int>(type: "int", nullable: false),
                    isUpdated = table.Column<bool>(type: "bit", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReplyOF = table.Column<int>(type: "int", nullable: false),
                    ChannelID = table.Column<int>(type: "int", nullable: true),
                    GroupID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Messages_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Messages_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AccountPVs",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    PVID = table.Column<int>(type: "int", nullable: false),
                    partnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPVs", x => new { x.AccountID, x.PVID });
                    table.ForeignKey(
                        name: "FK_AccountPVs_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPVs_PVs_PVID",
                        column: x => x.PVID,
                        principalTable: "PVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelAccountMessages",
                columns: table => new
                {
                    ChannelID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: false),
                    receiveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    seenTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelAccountMessages", x => new { x.ChannelID, x.AccountID, x.MessageID });
                    table.ForeignKey(
                        name: "FK_ChannelAccountMessages_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelAccountMessages_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelAccountMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelMessages",
                columns: table => new
                {
                    ChannelID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelMessages", x => new { x.ChannelID, x.MessageID });
                    table.ForeignKey(
                        name: "FK_ChannelMessages_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupAccountMessages",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: false),
                    receiveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    seenTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAccountMessages", x => new { x.GroupID, x.AccountID, x.MessageID });
                    table.ForeignKey(
                        name: "FK_GroupAccountMessages_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAccountMessages_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAccountMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMessages",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMessages", x => new { x.GroupID, x.MessageID });
                    table.ForeignKey(
                        name: "FK_GroupMessages_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVAccountMessages",
                columns: table => new
                {
                    PVID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: false),
                    receiveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    seenTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVAccountMessages", x => new { x.PVID, x.AccountID, x.MessageID });
                    table.ForeignKey(
                        name: "FK_PVAccountMessages_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVAccountMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVAccountMessages_PVs_PVID",
                        column: x => x.PVID,
                        principalTable: "PVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PVMessages",
                columns: table => new
                {
                    PVID = table.Column<int>(type: "int", nullable: false),
                    MessageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PVMessages", x => new { x.PVID, x.MessageID });
                    table.ForeignKey(
                        name: "FK_PVMessages_Messages_MessageID",
                        column: x => x.MessageID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PVMessages_PVs_PVID",
                        column: x => x.PVID,
                        principalTable: "PVs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannel_membersID",
                table: "AccountChannel",
                column: "membersID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannels_ChannelID",
                table: "AccountChannels",
                column: "ChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContacts_ContactID",
                table: "AccountContacts",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountGroup_membersID",
                table: "AccountGroup",
                column: "membersID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountGroups_GroupID",
                table: "AccountGroups",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPVs_PVID",
                table: "AccountPVs",
                column: "PVID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelAccountMessages_AccountID",
                table: "ChannelAccountMessages",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelAccountMessages_MessageID",
                table: "ChannelAccountMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessages_MessageID",
                table: "ChannelMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAccountMessages_AccountID",
                table: "GroupAccountMessages",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAccountMessages_MessageID",
                table: "GroupAccountMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_MessageID",
                table: "GroupMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChannelID",
                table: "Messages",
                column: "ChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_GroupID",
                table: "Messages",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_PVAccountMessages_AccountID",
                table: "PVAccountMessages",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_PVAccountMessages_MessageID",
                table: "PVAccountMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_PVMessages_MessageID",
                table: "PVMessages",
                column: "MessageID");

            migrationBuilder.CreateIndex(
                name: "IX_PVs_AccountID",
                table: "PVs",
                column: "AccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountChannel");

            migrationBuilder.DropTable(
                name: "AccountChannels");

            migrationBuilder.DropTable(
                name: "AccountContacts");

            migrationBuilder.DropTable(
                name: "AccountGroup");

            migrationBuilder.DropTable(
                name: "AccountGroups");

            migrationBuilder.DropTable(
                name: "AccountPVs");

            migrationBuilder.DropTable(
                name: "ChannelAccountMessages");

            migrationBuilder.DropTable(
                name: "ChannelMessages");

            migrationBuilder.DropTable(
                name: "GroupAccountMessages");

            migrationBuilder.DropTable(
                name: "GroupMessages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PVAccountMessages");

            migrationBuilder.DropTable(
                name: "PVMessages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PVs");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
