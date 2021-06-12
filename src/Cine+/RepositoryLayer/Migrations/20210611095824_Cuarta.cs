using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Cuarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apply");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.AddColumn<int>(
                name: "DiscountListId",
                table: "TicketPurchase",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartnerCode",
                table: "TicketPurchase",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsSpent",
                table: "TicketPurchase",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "TicketPurchase",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchase_DiscountListId",
                table: "TicketPurchase",
                column: "DiscountListId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchase_PartnerCode",
                table: "TicketPurchase",
                column: "PartnerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketPurchase_DiscountList_DiscountListId",
                table: "TicketPurchase",
                column: "DiscountListId",
                principalTable: "DiscountList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketPurchase_Partner_PartnerCode",
                table: "TicketPurchase",
                column: "PartnerCode",
                principalTable: "Partner",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketPurchase_DiscountList_DiscountListId",
                table: "TicketPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketPurchase_Partner_PartnerCode",
                table: "TicketPurchase");

            migrationBuilder.DropIndex(
                name: "IX_TicketPurchase_DiscountListId",
                table: "TicketPurchase");

            migrationBuilder.DropIndex(
                name: "IX_TicketPurchase_PartnerCode",
                table: "TicketPurchase");

            migrationBuilder.DropColumn(
                name: "DiscountListId",
                table: "TicketPurchase");

            migrationBuilder.DropColumn(
                name: "PartnerCode",
                table: "TicketPurchase");

            migrationBuilder.DropColumn(
                name: "PointsSpent",
                table: "TicketPurchase");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TicketPurchase");

            migrationBuilder.CreateTable(
                name: "Apply",
                columns: table => new
                {
                    TicketPurchaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountListId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    TicketPurchaseScheduleEndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketPurchaseScheduleStartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketPurchaseSeatCinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseSeatId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apply", x => x.TicketPurchaseId);
                    table.ForeignKey(
                        name: "FK_Apply_DiscountList_DiscountListId",
                        column: x => x.DiscountListId,
                        principalTable: "DiscountList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apply_TicketPurchase_TicketPurchaseSeatCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleStartTime_TicketPurchaseScheduleEndTime",
                        columns: x => new { x.TicketPurchaseSeatCinemaId, x.TicketPurchaseSeatId, x.TicketPurchaseScheduleStartTime, x.TicketPurchaseScheduleEndTime },
                        principalTable: "TicketPurchase",
                        principalColumns: new[] { "SeatCinemaId", "SeatId", "ScheduleStartTime", "ScheduleEndTime" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    TicketPurchaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartnerCode = table.Column<int>(type: "INTEGER", nullable: false),
                    PointsSpent = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseScheduleEndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketPurchaseScheduleStartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketPurchaseSeatCinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseSeatId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.TicketPurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchase_Partner_PartnerCode",
                        column: x => x.PartnerCode,
                        principalTable: "Partner",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_TicketPurchase_TicketPurchaseSeatCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleStartTime_TicketPurchaseScheduleEndTime",
                        columns: x => new { x.TicketPurchaseSeatCinemaId, x.TicketPurchaseSeatId, x.TicketPurchaseScheduleStartTime, x.TicketPurchaseScheduleEndTime },
                        principalTable: "TicketPurchase",
                        principalColumns: new[] { "SeatCinemaId", "SeatId", "ScheduleStartTime", "ScheduleEndTime" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apply_DiscountListId",
                table: "Apply",
                column: "DiscountListId");

            migrationBuilder.CreateIndex(
                name: "IX_Apply_TicketPurchaseSeatCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleStartTime_TicketPurchaseScheduleEndTime",
                table: "Apply",
                columns: new[] { "TicketPurchaseSeatCinemaId", "TicketPurchaseSeatId", "TicketPurchaseScheduleStartTime", "TicketPurchaseScheduleEndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PartnerCode",
                table: "Purchase",
                column: "PartnerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_TicketPurchaseSeatCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleStartTime_TicketPurchaseScheduleEndTime",
                table: "Purchase",
                columns: new[] { "TicketPurchaseSeatCinemaId", "TicketPurchaseSeatId", "TicketPurchaseScheduleStartTime", "TicketPurchaseScheduleEndTime" });
        }
    }
}
