using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentDatabase.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "UniqueItems",
                columns: table => new
                {
                    UniqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueItemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueItems", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Durability = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defence = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Inteligence = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    UniqueId = table.Column<int>(nullable: false),
                    UniqueItemUniqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_UniqueItems_UniqueItemUniqueId",
                        column: x => x.UniqueItemUniqueId,
                        principalTable: "UniqueItems",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rarety",
                columns: table => new
                {
                    RaretyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rarety = table.Column<string>(nullable: true),
                    MaxPoints = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    UniqueId = table.Column<int>(nullable: false),
                    UniqueItemUniqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarety", x => x.RaretyId);
                    table.ForeignKey(
                        name: "FK_Rarety_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rarety_UniqueItems_UniqueItemUniqueId",
                        column: x => x.UniqueItemUniqueId,
                        principalTable: "UniqueItems",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    UniqueId = table.Column<int>(nullable: false),
                    UniqueItemUniqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Type_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Type_UniqueItems_UniqueItemUniqueId",
                        column: x => x.UniqueItemUniqueId,
                        principalTable: "UniqueItems",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ItemId",
                table: "Properties",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UniqueItemUniqueId",
                table: "Properties",
                column: "UniqueItemUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Rarety_ItemId",
                table: "Rarety",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Rarety_UniqueItemUniqueId",
                table: "Rarety",
                column: "UniqueItemUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_ItemId",
                table: "Type",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_UniqueItemUniqueId",
                table: "Type",
                column: "UniqueItemUniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Rarety");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "UniqueItems");
        }
    }
}
