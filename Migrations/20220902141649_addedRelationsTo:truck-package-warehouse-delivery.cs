using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wms.Migrations
{
    public partial class addedRelationsTotruckpackagewarehousedelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminToWarehouseId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoredAtWarehouseId",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DrivenById",
                table: "Deliveries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "Deliveries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseFromId",
                table: "Deliveries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseToId",
                table: "Deliveries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TruckUser",
                columns: table => new
                {
                    DriversId = table.Column<int>(type: "integer", nullable: false),
                    TrucksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckUser", x => new { x.DriversId, x.TrucksId });
                    table.ForeignKey(
                        name: "FK_TruckUser_Trucks_TrucksId",
                        column: x => x.TrucksId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckUser_Users_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminToWarehouseId",
                table: "Users",
                column: "AdminToWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DeliveryId",
                table: "Packages",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_StoredAtWarehouseId",
                table: "Packages",
                column: "StoredAtWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DrivenById",
                table: "Deliveries",
                column: "DrivenById");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_TruckId",
                table: "Deliveries",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_WarehouseFromId",
                table: "Deliveries",
                column: "WarehouseFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_WarehouseToId",
                table: "Deliveries",
                column: "WarehouseToId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckUser_TrucksId",
                table: "TruckUser",
                column: "TrucksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Trucks_TruckId",
                table: "Deliveries",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_DrivenById",
                table: "Deliveries",
                column: "DrivenById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Warehouses_WarehouseFromId",
                table: "Deliveries",
                column: "WarehouseFromId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Warehouses_WarehouseToId",
                table: "Deliveries",
                column: "WarehouseToId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Deliveries_DeliveryId",
                table: "Packages",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Warehouses_StoredAtWarehouseId",
                table: "Packages",
                column: "StoredAtWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Warehouses_AdminToWarehouseId",
                table: "Users",
                column: "AdminToWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Trucks_TruckId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_DrivenById",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Warehouses_WarehouseFromId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Warehouses_WarehouseToId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Deliveries_DeliveryId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Warehouses_StoredAtWarehouseId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Warehouses_AdminToWarehouseId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "TruckUser");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdminToWarehouseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Packages_DeliveryId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_StoredAtWarehouseId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_DrivenById",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_TruckId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_WarehouseFromId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_WarehouseToId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "AdminToWarehouseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "StoredAtWarehouseId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DrivenById",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "WarehouseFromId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "WarehouseToId",
                table: "Deliveries");
        }
    }
}
