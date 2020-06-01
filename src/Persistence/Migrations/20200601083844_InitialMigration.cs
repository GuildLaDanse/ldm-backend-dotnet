using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaDanse.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentGroup",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    postDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentGroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GameClass",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    gameId = table.Column<uint>(type: "INT UNSIGNED", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameClass", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GameFaction",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    gameId = table.Column<uint>(type: "INT UNSIGNED", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFaction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GameRealm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameId = table.Column<uint>(type: "INT UNSIGNED", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRealm", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MailSend",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    sendOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    fromAddress = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    toAddress = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    subject = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailSend", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    externalId = table.Column<string>(type: "varchar(127)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    email = table.Column<string>(type: "varchar(180)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    displayName = table.Column<string>(type: "varchar(35)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GameRace",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    gameId = table.Column<uint>(type: "INT UNSIGNED", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameFactionId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRace", x => x.id);
                    table.ForeignKey(
                        name: "FK_D51A7CF883048B90",
                        column: x => x.gameFactionId,
                        principalTable: "GameFaction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacter",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameRealmId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacter", x => x.id);
                    table.ForeignKey(
                        name: "FK_92AF3B34FA96DBDA",
                        column: x => x.gameRealmId,
                        principalTable: "GameRealm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameGuild",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameId = table.Column<uint>(type: "INT UNSIGNED", nullable: false),
                    gameRealmId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGuild", x => x.id);
                    table.ForeignKey(
                        name: "FK_B48152AFFA96DBDA",
                        column: x => x.gameRealmId,
                        principalTable: "GameRealm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityQueueItem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    activityType = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    activityOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    rawData = table.Column<string>(type: "LONGTEXT", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    processedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    activityById = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityQueueItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_8A274BCA93C757EE",
                        column: x => x.activityById,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarExport",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    exportNew = table.Column<bool>(nullable: false),
                    exportAbsence = table.Column<bool>(nullable: false),
                    secret = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarExport", x => x.id);
                    table.ForeignKey(
                        name: "FK_6E28848862DEB3E8",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    postDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    content = table.Column<string>(type: "varchar(4096)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    groupId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    posterId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_5BC96BF0ED8188B0",
                        column: x => x.groupId,
                        principalTable: "CommentGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_5BC96BF0581A197",
                        column: x => x.posterId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    description = table.Column<string>(type: "varchar(4096)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    inviteTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    startTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    lastModifiedTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    state = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    commentGroupId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    organiserId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.id);
                    table.ForeignKey(
                        name: "FK_FA6F25A34BDD4B9",
                        column: x => x.commentGroupId,
                        principalTable: "CommentGroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FA6F25A34BDD3C8",
                        column: x => x.organiserId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeatureToggle",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    feature = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    toggle = table.Column<bool>(nullable: false),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureToggle", x => x.id);
                    table.ForeignKey(
                        name: "FK_D25E05DD612E729E",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeatureUse",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    usedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    feature = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    rawData = table.Column<string>(type: "LONGTEXT", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    usedById = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureUse", x => x.id);
                    table.ForeignKey(
                        name: "FK_E504F432FCEF271C",
                        column: x => x.usedById,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    postedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    feedback = table.Column<string>(type: "LONGTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    postedById = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_2B5F260E9DD8CB47",
                        column: x => x.postedById,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumLastVisit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    lastVisitDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumLastVisit", x => x.id);
                    table.ForeignKey(
                        name: "FK_F17408662DEB3E8",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationQueueItem",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    activityType = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    activityOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    rawData = table.Column<string>(type: "LONGTEXT", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    processedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    activityById = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationQueueItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_C656D44393C757EE",
                        column: x => x.activityById,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    value = table.Column<string>(type: "varchar(2048)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.id);
                    table.ForeignKey(
                        name: "FK_50C9810462DEB3E8",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterClaim",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameCharacterId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterClaim", x => x.id);
                    table.ForeignKey(
                        name: "FK_E115ED785AF690F3",
                        column: x => x.gameCharacterId,
                        principalTable: "GameCharacter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_E115ED7862DEB3E8",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterVersion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    level = table.Column<uint>(type: "INT UNSIGNED", nullable: false),
                    gameCharacterId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameClassId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameRaceId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterVersion", x => x.id);
                    table.ForeignKey(
                        name: "FK_A70EBD185AF690F3",
                        column: x => x.gameCharacterId,
                        principalTable: "GameCharacter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_A70EBD18F3B4E37B",
                        column: x => x.gameClassId,
                        principalTable: "GameClass",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_A70EBD18E036C39A",
                        column: x => x.gameRaceId,
                        principalTable: "GameRace",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterSource",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    discr = table.Column<string>(type: "char(15)", nullable: false),
                    gameGuildId = table.Column<Guid>(type: "CHAR(36)", nullable: true),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterSource", x => x.id);
                    table.ForeignKey(
                        name: "FK_18BD775675407DAB",
                        column: x => x.gameGuildId,
                        principalTable: "GameGuild",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_70D670C87D3656A4",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InGameGuild",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    gameCharacterId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameGuildId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InGameGuild", x => x.id);
                    table.ForeignKey(
                        name: "FK_CA2244C5AF690F3",
                        column: x => x.gameCharacterId,
                        principalTable: "GameCharacter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CA2244C75407DAB",
                        column: x => x.gameGuildId,
                        principalTable: "GameGuild",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SignUp",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    type = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    eventId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUp", x => x.id);
                    table.ForeignKey(
                        name: "FK_DC8B3F7B2B2EBB6C",
                        column: x => x.eventId,
                        principalTable: "Event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DC8B3F7B62DEB3E8",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterClaimVersion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    comment = table.Column<string>(type: "TEXT", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    isRaider = table.Column<bool>(nullable: false),
                    gameCharacterClaimId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterClaimVersion", x => x.id);
                    table.ForeignKey(
                        name: "FK_C33F42E09113A92D",
                        column: x => x.gameCharacterClaimId,
                        principalTable: "GameCharacterClaim",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaysGameRole",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    gameRole = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    gameCharacterClaimId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaysGameRole", x => x.id);
                    table.ForeignKey(
                        name: "FK_7A9E9B239113A92D",
                        column: x => x.gameCharacterClaimId,
                        principalTable: "GameCharacterClaim",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameCharacterSyncSession",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    log = table.Column<string>(type: "LONGTEXT", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameCharacterSourceId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCharacterSyncSession", x => x.id);
                    table.ForeignKey(
                        name: "FK_EC73362CDD71BB",
                        column: x => x.gameCharacterSourceId,
                        principalTable: "GameCharacterSource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackedBy",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    fromTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    endTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    gameCharacterId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    gameCharacterSourceId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackedBy", x => x.id);
                    table.ForeignKey(
                        name: "FK_C2316E125AF690F3",
                        column: x => x.gameCharacterId,
                        principalTable: "GameCharacter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_C2316E122CDD71BB",
                        column: x => x.gameCharacterSourceId,
                        principalTable: "GameCharacterSource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SignedForGameRole",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    gameRole = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    signUpId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignedForGameRole", x => x.id);
                    table.ForeignKey(
                        name: "FK_16186B55A966702F",
                        column: x => x.signUpId,
                        principalTable: "SignUp",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    postDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    subject = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    lastPostDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    forumId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    lastPostPosterId = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    posterId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.id);
                    table.ForeignKey(
                        name: "FK_5C81F11F22F0147C",
                        column: x => x.lastPostPosterId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_5C81F11F581A197",
                        column: x => x.posterId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    description = table.Column<string>(type: "TEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    lastPostDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    lastPostPosterId = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    lastPostTopicId = table.Column<Guid>(type: "CHAR(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.id);
                    table.ForeignKey(
                        name: "FK_44EA91C922F0147C",
                        column: x => x.lastPostPosterId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_44EA91C91CA16452",
                        column: x => x.lastPostTopicId,
                        principalTable: "Topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    postDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    content = table.Column<string>(type: "LONGTEXT", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    posterId = table.Column<Guid>(nullable: false, comment: "CHAR(36)"),
                    topicId = table.Column<Guid>(nullable: false, comment: "CHAR(36)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                    table.ForeignKey(
                        name: "FK_FAB8C3B3581A197",
                        column: x => x.posterId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAB8C3B3E2E0EAFB",
                        column: x => x.topicId,
                        principalTable: "Topic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnreadPost",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "CHAR(36)", nullable: false),
                    userId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci"),
                    postId = table.Column<Guid>(type: "CHAR(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_unicode_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnreadPost", x => x.id);
                    table.ForeignKey(
                        name: "FK_6B0B9B3EE094D20D",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_6B0B9B3E62DEB3E8",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_8A274BCA93C757EE",
                table: "ActivityQueueItem",
                column: "activityById");

            migrationBuilder.CreateIndex(
                name: "IDX_6E28848862DEB3E8",
                table: "CalendarExport",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IDX_5BC96BF0ED8188B0",
                table: "Comment",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IDX_5BC96BF0581A197",
                table: "Comment",
                column: "posterId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_commentGroupId",
                table: "Event",
                column: "commentGroupId");

            migrationBuilder.CreateIndex(
                name: "IDX_FA6F25A34BDD3C8",
                table: "Event",
                column: "organiserId");

            migrationBuilder.CreateIndex(
                name: "IDX_D25E05DD612E729E",
                table: "FeatureToggle",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IDX_E504F432FCEF271C",
                table: "FeatureUse",
                column: "usedById");

            migrationBuilder.CreateIndex(
                name: "IDX_2B5F260E9DD8CB47",
                table: "Feedback",
                column: "postedById");

            migrationBuilder.CreateIndex(
                name: "IDX_44EA91C922F0147C",
                table: "Forum",
                column: "lastPostPosterId");

            migrationBuilder.CreateIndex(
                name: "IDX_44EA91C91CA16452",
                table: "Forum",
                column: "lastPostTopicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_F17408662DEB3E8",
                table: "ForumLastVisit",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IDX_92AF3B34FA96DBDA",
                table: "GameCharacter",
                column: "gameRealmId");

            migrationBuilder.CreateIndex(
                name: "IDX_E115ED785AF690F3",
                table: "GameCharacterClaim",
                column: "gameCharacterId");

            migrationBuilder.CreateIndex(
                name: "IDX_E115ED7862DEB3E8",
                table: "GameCharacterClaim",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IDX_C33F42E09113A92D",
                table: "GameCharacterClaimVersion",
                column: "gameCharacterClaimId");

            migrationBuilder.CreateIndex(
                name: "IDX_18BD775675407DAB",
                table: "GameCharacterSource",
                column: "gameGuildId");

            migrationBuilder.CreateIndex(
                name: "IDX_70D670C87D3656A4",
                table: "GameCharacterSource",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IDX_EC73362CDD71BB",
                table: "GameCharacterSyncSession",
                column: "gameCharacterSourceId");

            migrationBuilder.CreateIndex(
                name: "IDX_A70EBD185AF690F3",
                table: "GameCharacterVersion",
                column: "gameCharacterId");

            migrationBuilder.CreateIndex(
                name: "IDX_A70EBD18F3B4E37B",
                table: "GameCharacterVersion",
                column: "gameClassId");

            migrationBuilder.CreateIndex(
                name: "IDX_A70EBD18E036C39A",
                table: "GameCharacterVersion",
                column: "gameRaceId");

            migrationBuilder.CreateIndex(
                name: "IDX_B48152AFFA96DBDA",
                table: "GameGuild",
                column: "gameRealmId");

            migrationBuilder.CreateIndex(
                name: "IDX_D51A7CF883048B90",
                table: "GameRace",
                column: "gameFactionId");

            migrationBuilder.CreateIndex(
                name: "IDX_CA2244C5AF690F3",
                table: "InGameGuild",
                column: "gameCharacterId");

            migrationBuilder.CreateIndex(
                name: "IDX_CA2244C75407DAB",
                table: "InGameGuild",
                column: "gameGuildId");

            migrationBuilder.CreateIndex(
                name: "IDX_C656D44393C757EE",
                table: "NotificationQueueItem",
                column: "activityById");

            migrationBuilder.CreateIndex(
                name: "IDX_7A9E9B239113A92D",
                table: "PlaysGameRole",
                column: "gameCharacterClaimId");

            migrationBuilder.CreateIndex(
                name: "IDX_FAB8C3B3581A197",
                table: "Post",
                column: "posterId");

            migrationBuilder.CreateIndex(
                name: "IDX_FAB8C3B3E2E0EAFB",
                table: "Post",
                column: "topicId");

            migrationBuilder.CreateIndex(
                name: "IDX_50C9810462DEB3E8",
                table: "Setting",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IDX_16186B55A966702F",
                table: "SignedForGameRole",
                column: "signUpId");

            migrationBuilder.CreateIndex(
                name: "IDX_DC8B3F7B2B2EBB6C",
                table: "SignUp",
                column: "eventId");

            migrationBuilder.CreateIndex(
                name: "IDX_DC8B3F7B62DEB3E8",
                table: "SignUp",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IDX_5C81F11F7830F151",
                table: "Topic",
                column: "forumId");

            migrationBuilder.CreateIndex(
                name: "IDX_5C81F11F22F0147C",
                table: "Topic",
                column: "lastPostPosterId");

            migrationBuilder.CreateIndex(
                name: "IDX_5C81F11F581A197",
                table: "Topic",
                column: "posterId");

            migrationBuilder.CreateIndex(
                name: "IDX_C2316E125AF690F3",
                table: "TrackedBy",
                column: "gameCharacterId");

            migrationBuilder.CreateIndex(
                name: "IDX_C2316E122CDD71BB",
                table: "TrackedBy",
                column: "gameCharacterSourceId");

            migrationBuilder.CreateIndex(
                name: "IDX_6B0B9B3EE094D20D",
                table: "UnreadPost",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IDX_6B0B9B3E62DEB3E8",
                table: "UnreadPost",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "UNIQ_B28B6F38A0D96FBF",
                table: "User",
                column: "displayName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNIQ_B28B6F3892FC23A8",
                table: "User",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UNIQ_B28B6F38C05FB297",
                table: "User",
                column: "externalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_5C81F11F7830F151",
                table: "Topic",
                column: "forumId",
                principalTable: "Forum",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_44EA91C922F0147C",
                table: "Forum");

            migrationBuilder.DropForeignKey(
                name: "FK_5C81F11F22F0147C",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_5C81F11F581A197",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_44EA91C91CA16452",
                table: "Forum");

            migrationBuilder.DropTable(
                name: "ActivityQueueItem");

            migrationBuilder.DropTable(
                name: "CalendarExport");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "FeatureToggle");

            migrationBuilder.DropTable(
                name: "FeatureUse");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "ForumLastVisit");

            migrationBuilder.DropTable(
                name: "GameCharacterClaimVersion");

            migrationBuilder.DropTable(
                name: "GameCharacterSyncSession");

            migrationBuilder.DropTable(
                name: "GameCharacterVersion");

            migrationBuilder.DropTable(
                name: "InGameGuild");

            migrationBuilder.DropTable(
                name: "MailSend");

            migrationBuilder.DropTable(
                name: "NotificationQueueItem");

            migrationBuilder.DropTable(
                name: "PlaysGameRole");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "SignedForGameRole");

            migrationBuilder.DropTable(
                name: "TrackedBy");

            migrationBuilder.DropTable(
                name: "UnreadPost");

            migrationBuilder.DropTable(
                name: "GameClass");

            migrationBuilder.DropTable(
                name: "GameRace");

            migrationBuilder.DropTable(
                name: "GameCharacterClaim");

            migrationBuilder.DropTable(
                name: "SignUp");

            migrationBuilder.DropTable(
                name: "GameCharacterSource");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "GameFaction");

            migrationBuilder.DropTable(
                name: "GameCharacter");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "GameGuild");

            migrationBuilder.DropTable(
                name: "CommentGroup");

            migrationBuilder.DropTable(
                name: "GameRealm");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Forum");
        }
    }
}
