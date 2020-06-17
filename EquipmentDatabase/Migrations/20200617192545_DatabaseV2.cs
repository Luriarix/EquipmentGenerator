using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentDatabase.Migrations
{
    public partial class DatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Items_ItemId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_UniqueItems_UniqueItemUniqueId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Rarety_Items_ItemId",
                table: "Rarety");

            migrationBuilder.DropForeignKey(
                name: "FK_Rarety_UniqueItems_UniqueItemUniqueId",
                table: "Rarety");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Items_ItemId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_UniqueItems_UniqueItemUniqueId",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Type_ItemId",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Type_UniqueItemUniqueId",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Rarety_ItemId",
                table: "Rarety");

            migrationBuilder.DropIndex(
                name: "IX_Rarety_UniqueItemUniqueId",
                table: "Rarety");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ItemId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_UniqueItemUniqueId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "UniqueItemUniqueId",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Rarety");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "Rarety");

            migrationBuilder.DropColumn(
                name: "UniqueItemUniqueId",
                table: "Rarety");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UniqueItemUniqueId",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "UniqueItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaretyId",
                table: "UniqueItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "UniqueItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniqueItemPropertyPropertyId",
                table: "UniqueItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniqueItemRaretyRaretyId",
                table: "UniqueItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniqueItemTypeTypeId",
                table: "UniqueItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommonItemRaretyRaretyId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemPropertyPropertyId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeTypeId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RaretyId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Rarety_CommonItemRaretyRaretyId",
                table: "Items",
                column: "CommonItemRaretyRaretyId",
                principalTable: "Rarety",
                principalColumn: "RaretyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Properties_ItemPropertyPropertyId",
                table: "Items",
                column: "ItemPropertyPropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Type_ItemTypeTypeId",
                table: "Items",
                column: "ItemTypeTypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueItems_Properties_UniqueItemPropertyPropertyId",
                table: "UniqueItems",
                column: "UniqueItemPropertyPropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueItems_Rarety_UniqueItemRaretyRaretyId",
                table: "UniqueItems",
                column: "UniqueItemRaretyRaretyId",
                principalTable: "Rarety",
                principalColumn: "RaretyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniqueItems_Type_UniqueItemTypeTypeId",
                table: "UniqueItems",
                column: "UniqueItemTypeTypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Rarety_CommonItemRaretyRaretyId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Properties_ItemPropertyPropertyId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Type_ItemTypeTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_UniqueItems_Properties_UniqueItemPropertyPropertyId",
                table: "UniqueItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UniqueItems_Rarety_UniqueItemRaretyRaretyId",
                table: "UniqueItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UniqueItems_Type_UniqueItemTypeTypeId",
                table: "UniqueItems");

            migrationBuilder.DropIndex(
                name: "IX_UniqueItems_UniqueItemPropertyPropertyId",
                table: "UniqueItems");

            migrationBuilder.DropIndex(
                name: "IX_UniqueItems_UniqueItemRaretyRaretyId",
                table: "UniqueItems");

            migrationBuilder.DropIndex(
                name: "IX_UniqueItems_UniqueItemTypeTypeId",
                table: "UniqueItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_CommonItemRaretyRaretyId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemPropertyPropertyId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemTypeTypeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "UniqueItems");

            migrationBuilder.DropColumn(
                name: "RaretyId",
                table: "UniqueItems");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "UniqueItems");

            migrationBuilder.DropColumn(
                name: "UniqueItemPropertyPropertyId",
                table: "UniqueItems");

            migrationBuilder.DropColumn(
                name: "UniqueItemRaretyRaretyId",
                table: "UniqueItems");

            migrationBuilder.DropColumn(
                name: "UniqueItemTypeTypeId",
                table: "UniqueItems");

            migrationBuilder.DropColumn(
                name: "CommonItemRaretyRaretyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemPropertyPropertyId",
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
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniqueId",
                table: "Type",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniqueItemUniqueId",
                table: "Type",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Rarety",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniqueId",
                table: "Rarety",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniqueItemUniqueId",
                table: "Rarety",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniqueId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniqueItemUniqueId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Type_ItemId",
                table: "Type",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_UniqueItemUniqueId",
                table: "Type",
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
                name: "IX_Properties_ItemId",
                table: "Properties",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UniqueItemUniqueId",
                table: "Properties",
                column: "UniqueItemUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Items_ItemId",
                table: "Properties",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_UniqueItems_UniqueItemUniqueId",
                table: "Properties",
                column: "UniqueItemUniqueId",
                principalTable: "UniqueItems",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rarety_Items_ItemId",
                table: "Rarety",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rarety_UniqueItems_UniqueItemUniqueId",
                table: "Rarety",
                column: "UniqueItemUniqueId",
                principalTable: "UniqueItems",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Items_ItemId",
                table: "Type",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_UniqueItems_UniqueItemUniqueId",
                table: "Type",
                column: "UniqueItemUniqueId",
                principalTable: "UniqueItems",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
