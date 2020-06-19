using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentDatabase.Migrations
{
    public partial class Database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Rarety_CommonItemRaretyRaretyId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Type_ItemTypeTypeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CommonItemRaretyRaretyId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CommonItemRaretyRaretyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemTypeTypeId",
                table: "Items");

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
                name: "ItemId",
                table: "Type",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Rarety",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyForeignId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaretyForeignId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeForeignId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Type_ItemId",
                table: "Type",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rarety_ItemId",
                table: "Rarety",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rarety_Items_ItemId",
                table: "Rarety",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Items_ItemId",
                table: "Type",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rarety_Items_ItemId",
                table: "Rarety");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Items_ItemId",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Type_ItemId",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Rarety_ItemId",
                table: "Rarety");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Rarety");

            migrationBuilder.DropColumn(
                name: "PropertyForeignId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RaretyForeignId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TypeForeignId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "CommonItemRaretyRaretyId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeTypeId",
                table: "Items",
                type: "int",
                nullable: true);

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
                name: "IX_Items_CommonItemRaretyRaretyId",
                table: "Items",
                column: "CommonItemRaretyRaretyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeTypeId",
                table: "Items",
                column: "ItemTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Rarety_CommonItemRaretyRaretyId",
                table: "Items",
                column: "CommonItemRaretyRaretyId",
                principalTable: "Rarety",
                principalColumn: "RaretyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Type_ItemTypeTypeId",
                table: "Items",
                column: "ItemTypeTypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
