using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentDatabase.Migrations
{
    public partial class database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Items_ItemId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ItemId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RaretyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemPropertyPropertyId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemPropertyPropertyId",
                table: "Items",
                column: "ItemPropertyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Properties_ItemPropertyPropertyId",
                table: "Items",
                column: "ItemPropertyPropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Properties_ItemPropertyPropertyId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemPropertyPropertyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemPropertyPropertyId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaretyId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ItemId",
                table: "Properties",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Items_ItemId",
                table: "Properties",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
