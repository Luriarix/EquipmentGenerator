using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentDatabase.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Inteligence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                });

            migrationBuilder.CreateTable(
                name: "Rarety",
                columns: table => new
                {
                    RaretyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rarety = table.Column<string>(nullable: true),
                    MaxPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarety", x => x.RaretyId);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    ItemTypeTypeId = table.Column<int>(nullable: true),
                    CommonItemRaretyRaretyId = table.Column<int>(nullable: true),
                    ItemPropertyPropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Rarety_CommonItemRaretyRaretyId",
                        column: x => x.CommonItemRaretyRaretyId,
                        principalTable: "Rarety",
                        principalColumn: "RaretyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Properties_ItemPropertyPropertyId",
                        column: x => x.ItemPropertyPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Type_ItemTypeTypeId",
                        column: x => x.ItemTypeTypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniqueItems",
                columns: table => new
                {
                    UniqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueItemName = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    UniqueItemTypeTypeId = table.Column<int>(nullable: true),
                    RaretyId = table.Column<int>(nullable: false),
                    UniqueItemRaretyRaretyId = table.Column<int>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false),
                    UniqueItemPropertyPropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueItems", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_UniqueItems_Properties_UniqueItemPropertyPropertyId",
                        column: x => x.UniqueItemPropertyPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniqueItems_Rarety_UniqueItemRaretyRaretyId",
                        column: x => x.UniqueItemRaretyRaretyId,
                        principalTable: "Rarety",
                        principalColumn: "RaretyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniqueItems_Type_UniqueItemTypeTypeId",
                        column: x => x.UniqueItemTypeTypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CommonItemRaretyRaretyId",
                table: "Items",
                column: "CommonItemRaretyRaretyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemPropertyPropertyId",
                table: "Items",
                column: "ItemPropertyPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeTypeId",
                table: "Items",
                column: "ItemTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueItems_UniqueItemPropertyPropertyId",
                table: "UniqueItems",
                column: "UniqueItemPropertyPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueItems_UniqueItemRaretyRaretyId",
                table: "UniqueItems",
                column: "UniqueItemRaretyRaretyId");

            migrationBuilder.CreateIndex(
                name: "IX_UniqueItems_UniqueItemTypeTypeId",
                table: "UniqueItems",
                column: "UniqueItemTypeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "UniqueItems");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Rarety");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
