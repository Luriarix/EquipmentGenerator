using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentDatabase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    LowestItemRarety = table.Column<string>(nullable: true),
                    HighestItemRarety = table.Column<string>(nullable: true),
                    AmountOfProperties = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                });

            migrationBuilder.CreateTable(
                name: "Rarety",
                columns: table => new
                {
                    RaretyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rarety = table.Column<string>(nullable: true)
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
                name: "UniqueItems",
                columns: table => new
                {
                    UniqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueItemName = table.Column<string>(nullable: true),
                    UniqueItemType = table.Column<string>(nullable: true),
                    UniqueItemRarety = table.Column<string>(nullable: true),
                    UniqueItemProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueItems", x => x.UniqueId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Rarety");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "UniqueItems");
        }
    }
}
