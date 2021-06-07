using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DiscountedMoney = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalDiscounted = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    Points = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => new { x.StartTime, x.EndTime });
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ubication = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CinemaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountDiscountList",
                columns: table => new
                {
                    DiscountListsId = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountDiscountList", x => new { x.DiscountListsId, x.DiscountsId });
                    table.ForeignKey(
                        name: "FK_DiscountDiscountList_Discount_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountDiscountList_DiscountList_DiscountListsId",
                        column: x => x.DiscountListsId,
                        principalTable: "DiscountList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryMovie",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMovie", x => new { x.CountriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CountryMovie_Country_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleStartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ScheduleEndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => new { x.MovieId, x.CinemaId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_Batch_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batch_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batch_Schedule_ScheduleStartTime_ScheduleEndTime",
                        columns: x => new { x.ScheduleStartTime, x.ScheduleEndTime },
                        principalTable: "Schedule",
                        principalColumns: new[] { "StartTime", "EndTime" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchase",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "INTEGER", nullable: false),
                    CinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleStartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ScheduleEndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    CreditCard = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchase", x => new { x.CinemaId, x.SeatId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_TicketPurchase_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchase_Schedule_ScheduleStartTime_ScheduleEndTime",
                        columns: x => new { x.ScheduleStartTime, x.ScheduleEndTime },
                        principalTable: "Schedule",
                        principalColumns: new[] { "StartTime", "EndTime" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchase_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apply",
                columns: table => new
                {
                    TicketPurchaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountListId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseCinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseSeatId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false)
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
                        name: "FK_Apply_TicketPurchase_TicketPurchaseCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleId",
                        columns: x => new { x.TicketPurchaseCinemaId, x.TicketPurchaseSeatId, x.TicketPurchaseScheduleId },
                        principalTable: "TicketPurchase",
                        principalColumns: new[] { "CinemaId", "SeatId", "ScheduleId" },
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
                    TicketPurchaseCinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseSeatId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketPurchaseScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Purchase_TicketPurchase_TicketPurchaseCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleId",
                        columns: x => new { x.TicketPurchaseCinemaId, x.TicketPurchaseSeatId, x.TicketPurchaseScheduleId },
                        principalTable: "TicketPurchase",
                        principalColumns: new[] { "CinemaId", "SeatId", "ScheduleId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apply_DiscountListId",
                table: "Apply",
                column: "DiscountListId");

            migrationBuilder.CreateIndex(
                name: "IX_Apply_TicketPurchaseCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleId",
                table: "Apply",
                columns: new[] { "TicketPurchaseCinemaId", "TicketPurchaseSeatId", "TicketPurchaseScheduleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Batch_CinemaId",
                table: "Batch",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Batch_ScheduleStartTime_ScheduleEndTime",
                table: "Batch",
                columns: new[] { "ScheduleStartTime", "ScheduleEndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryMovie_MoviesId",
                table: "CountryMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountDiscountList_DiscountsId",
                table: "DiscountDiscountList",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PartnerCode",
                table: "Purchase",
                column: "PartnerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_TicketPurchaseCinemaId_TicketPurchaseSeatId_TicketPurchaseScheduleId",
                table: "Purchase",
                columns: new[] { "TicketPurchaseCinemaId", "TicketPurchaseSeatId", "TicketPurchaseScheduleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_CinemaId",
                table: "Seat",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchase_ScheduleStartTime_ScheduleEndTime",
                table: "TicketPurchase",
                columns: new[] { "ScheduleStartTime", "ScheduleEndTime" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchase_SeatId",
                table: "TicketPurchase",
                column: "SeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apply");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "CountryMovie");

            migrationBuilder.DropTable(
                name: "DiscountDiscountList");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "DiscountList");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "TicketPurchase");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}
