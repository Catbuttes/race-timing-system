using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    DriverValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    RaceValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    RaceDriverValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    LapValid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    User = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    User = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagCategorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DriverValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    RaceValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    RaceDriverValid = table.Column<bool>(type: "INTEGER", nullable: false),
                    LapValid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefinitionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverAttributes_AttributeDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "AttributeDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverAttributes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    RaceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefinitionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceAttributes_AttributeDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "AttributeDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceAttributes_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceDrivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RaceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDrivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceDrivers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceDrivers_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagDefinitions_TagCategorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TagCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RaceDriverId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laps_RaceDrivers_RaceDriverId",
                        column: x => x.RaceDriverId,
                        principalTable: "RaceDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceDriverAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    RaceDriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefinitionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDriverAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceDriverAttributes_AttributeDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "AttributeDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceDriverAttributes_RaceDrivers_RaceDriverId",
                        column: x => x.RaceDriverId,
                        principalTable: "RaceDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverTags_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverTags_TagDefinitions_TagId",
                        column: x => x.TagId,
                        principalTable: "TagDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceDriverTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RaceDriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceDriverTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceDriverTags_RaceDrivers_RaceDriverId",
                        column: x => x.RaceDriverId,
                        principalTable: "RaceDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceDriverTags_TagDefinitions_TagId",
                        column: x => x.TagId,
                        principalTable: "TagDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RaceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceTags_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceTags_TagDefinitions_TagId",
                        column: x => x.TagId,
                        principalTable: "TagDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LapAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    LapId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefinitionId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LapAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LapAttributes_AttributeDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "AttributeDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LapAttributes_Laps_LapId",
                        column: x => x.LapId,
                        principalTable: "Laps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LapTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LapId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LapTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LapTags_Laps_LapId",
                        column: x => x.LapId,
                        principalTable: "Laps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LapTags_TagDefinitions_TagId",
                        column: x => x.TagId,
                        principalTable: "TagDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AttributeDefinitions",
                columns: new[] { "Id", "Description", "DriverValid", "LapValid", "Name", "RaceDriverValid", "RaceValid", "Type" },
                values: new object[] { new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"), "The team the driver belongs to", true, false, "Team", true, false, "SingleLineOfText" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Name", "User" },
                values: new object[] { new Guid("6a4bc4bb-fa80-45fa-aace-4865837e928a"), "Driver 3", new Guid("46733858-a61e-4d98-8a68-23fbf3849ad2") });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Name", "User" },
                values: new object[] { new Guid("8f9c7d3a-fae0-4570-a619-67d26f070ff5"), "Driver 1", new Guid("8044f000-95ee-4fd9-9707-4ee9737af0cf") });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Name", "User" },
                values: new object[] { new Guid("d6a9074d-5eb0-4fef-a16e-a024f14edfca"), "Driver 2", new Guid("d77eeabb-adb5-440b-88b4-d3af56a7fbb2") });

            migrationBuilder.InsertData(
                table: "TagCategorys",
                columns: new[] { "Id", "Description", "DriverValid", "LapValid", "Name", "RaceDriverValid", "RaceValid" },
                values: new object[] { new Guid("cd4f4040-d248-412f-86b2-38fffc580398"), "The tyre the driver prefers", true, false, "Tyre", true, false });

            migrationBuilder.InsertData(
                table: "DriverAttributes",
                columns: new[] { "Id", "DefinitionId", "DriverId", "Value" },
                values: new object[] { new Guid("101d496f-acfd-42e8-912c-632593ba0d03"), new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"), new Guid("d6a9074d-5eb0-4fef-a16e-a024f14edfca"), "Team2" });

            migrationBuilder.InsertData(
                table: "DriverAttributes",
                columns: new[] { "Id", "DefinitionId", "DriverId", "Value" },
                values: new object[] { new Guid("1c537108-3001-43db-9fd5-b00fed55bdcb"), new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"), new Guid("8f9c7d3a-fae0-4570-a619-67d26f070ff5"), "Team1" });

            migrationBuilder.InsertData(
                table: "DriverAttributes",
                columns: new[] { "Id", "DefinitionId", "DriverId", "Value" },
                values: new object[] { new Guid("fd669999-4245-48b0-9ab9-1bd7e13f7a02"), new Guid("54a85f54-e87e-4b98-a2fd-a57dd2ab4df0"), new Guid("6a4bc4bb-fa80-45fa-aace-4865837e928a"), "Team3" });

            migrationBuilder.InsertData(
                table: "TagDefinitions",
                columns: new[] { "Id", "CategoryId", "Value" },
                values: new object[] { new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75"), new Guid("cd4f4040-d248-412f-86b2-38fffc580398"), "Soft" });

            migrationBuilder.InsertData(
                table: "DriverTags",
                columns: new[] { "Id", "DriverId", "TagId" },
                values: new object[] { new Guid("889a5af0-e848-42e0-b9a9-554428ba53e0"), new Guid("8f9c7d3a-fae0-4570-a619-67d26f070ff5"), new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75") });

            migrationBuilder.InsertData(
                table: "DriverTags",
                columns: new[] { "Id", "DriverId", "TagId" },
                values: new object[] { new Guid("cbb0efdc-eda1-4c3b-a50e-8f02550e2006"), new Guid("d6a9074d-5eb0-4fef-a16e-a024f14edfca"), new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75") });

            migrationBuilder.InsertData(
                table: "DriverTags",
                columns: new[] { "Id", "DriverId", "TagId" },
                values: new object[] { new Guid("f6818e9f-37fc-483e-8afd-8be3f7fab5c5"), new Guid("6a4bc4bb-fa80-45fa-aace-4865837e928a"), new Guid("b34104e1-efd8-46ec-80f3-b732f8aa6d75") });

            migrationBuilder.CreateIndex(
                name: "IX_DriverAttributes_DefinitionId",
                table: "DriverAttributes",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverAttributes_DriverId",
                table: "DriverAttributes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverTags_DriverId",
                table: "DriverTags",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverTags_TagId",
                table: "DriverTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_LapAttributes_DefinitionId",
                table: "LapAttributes",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_LapAttributes_LapId",
                table: "LapAttributes",
                column: "LapId");

            migrationBuilder.CreateIndex(
                name: "IX_Laps_RaceDriverId",
                table: "Laps",
                column: "RaceDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_LapTags_LapId",
                table: "LapTags",
                column: "LapId");

            migrationBuilder.CreateIndex(
                name: "IX_LapTags_TagId",
                table: "LapTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAttributes_DefinitionId",
                table: "RaceAttributes",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAttributes_RaceId",
                table: "RaceAttributes",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDriverAttributes_DefinitionId",
                table: "RaceDriverAttributes",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDriverAttributes_RaceDriverId",
                table: "RaceDriverAttributes",
                column: "RaceDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDrivers_DriverId",
                table: "RaceDrivers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDrivers_RaceId",
                table: "RaceDrivers",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDriverTags_RaceDriverId",
                table: "RaceDriverTags",
                column: "RaceDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceDriverTags_TagId",
                table: "RaceDriverTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTags_RaceId",
                table: "RaceTags",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTags_TagId",
                table: "RaceTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagDefinitions_CategoryId",
                table: "TagDefinitions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverAttributes");

            migrationBuilder.DropTable(
                name: "DriverTags");

            migrationBuilder.DropTable(
                name: "LapAttributes");

            migrationBuilder.DropTable(
                name: "LapTags");

            migrationBuilder.DropTable(
                name: "RaceAttributes");

            migrationBuilder.DropTable(
                name: "RaceDriverAttributes");

            migrationBuilder.DropTable(
                name: "RaceDriverTags");

            migrationBuilder.DropTable(
                name: "RaceTags");

            migrationBuilder.DropTable(
                name: "Laps");

            migrationBuilder.DropTable(
                name: "AttributeDefinitions");

            migrationBuilder.DropTable(
                name: "TagDefinitions");

            migrationBuilder.DropTable(
                name: "RaceDrivers");

            migrationBuilder.DropTable(
                name: "TagCategorys");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
