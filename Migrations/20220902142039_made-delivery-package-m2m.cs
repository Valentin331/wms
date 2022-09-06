using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wms.Migrations
{
    public partial class madedeliverypackagem2m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Deliveries_DeliveryId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_DeliveryId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Packages");

            migrationBuilder.CreateTable(
                name: "DeliveryPackage",
                columns: table => new
                {
                    DeliveriesId = table.Column<int>(type: "integer", nullable: false),
                    PackagesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPackage", x => new { x.DeliveriesId, x.PackagesId });
                    table.ForeignKey(
                        name: "FK_DeliveryPackage_Deliveries_DeliveriesId",
                        column: x => x.DeliveriesId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryPackage_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPackage_PackagesId",
                table: "DeliveryPackage",
                column: "PackagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryPackage");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Packages",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DeliveryId",
                table: "Packages",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Deliveries_DeliveryId",
                table: "Packages",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");
        }
    }
}
