using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class AddtheRestofModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovie_Country_CountriesID",
                table: "CountryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovie_Movie_MoviesID",
                table: "CountryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genre_GenresID",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movie_MoviesID",
                table: "GenreMovie");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Movie",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MoviesID",
                table: "GenreMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "GenresID",
                table: "GenreMovie",
                newName: "GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_GenreMovie_MoviesID",
                table: "GenreMovie",
                newName: "IX_GenreMovie_MoviesId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MoviesID",
                table: "CountryMovie",
                newName: "MoviesId");

            migrationBuilder.RenameColumn(
                name: "CountriesID",
                table: "CountryMovie",
                newName: "CountriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryMovie_MoviesID",
                table: "CountryMovie",
                newName: "IX_CountryMovie_MoviesId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Country",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Genre",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Country",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batch_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Purchase",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PartnerCode = table.Column<int>(type: "INTEGER", nullable: true),
                    PointsSpent = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PartnerId);
                    table.ForeignKey(
                        name: "FK_Purchase_Partner_PartnerCode",
                        column: x => x.PartnerCode,
                        principalTable: "Partner",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchase",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "INTEGER", nullable: false),
                    CinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    PartnerCode = table.Column<int>(type: "INTEGER", nullable: true),
                    PurchasePartnerId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreditCard = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchase", x => new { x.CinemaId, x.SeatId });
                    table.ForeignKey(
                        name: "FK_TicketPurchase_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchase_Partner_PartnerCode",
                        column: x => x.PartnerCode,
                        principalTable: "Partner",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketPurchase_Purchase_PurchasePartnerId",
                        column: x => x.PurchasePartnerId,
                        principalTable: "Purchase",
                        principalColumn: "PartnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketPurchase_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_BatchId",
                table: "Genre",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_BatchId",
                table: "Country",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Batch_MovieId",
                table: "Batch",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PartnerCode",
                table: "Purchase",
                column: "PartnerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_CinemaId",
                table: "Seat",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchase_PartnerCode",
                table: "TicketPurchase",
                column: "PartnerCode");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchase_PurchasePartnerId",
                table: "TicketPurchase",
                column: "PurchasePartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchase_SeatId",
                table: "TicketPurchase",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Country_Batch_BatchId",
                table: "Country",
                column: "BatchId",
                principalTable: "Batch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovie_Country_CountriesId",
                table: "CountryMovie",
                column: "CountriesId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovie_Movie_MoviesId",
                table: "CountryMovie",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Batch_BatchId",
                table: "Genre",
                column: "BatchId",
                principalTable: "Batch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genre_GenresId",
                table: "GenreMovie",
                column: "GenresId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Country_Batch_BatchId",
                table: "Country");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovie_Country_CountriesId",
                table: "CountryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovie_Movie_MoviesId",
                table: "CountryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Batch_BatchId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genre_GenresId",
                table: "GenreMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Movie_MoviesId",
                table: "GenreMovie");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "TicketPurchase");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "Cinema");

            migrationBuilder.DropIndex(
                name: "IX_Genre_BatchId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Country_BatchId",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Country");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "GenreMovie",
                newName: "MoviesID");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "GenreMovie",
                newName: "GenresID");

            migrationBuilder.RenameIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                newName: "IX_GenreMovie_MoviesID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genre",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "CountryMovie",
                newName: "MoviesID");

            migrationBuilder.RenameColumn(
                name: "CountriesId",
                table: "CountryMovie",
                newName: "CountriesID");

            migrationBuilder.RenameIndex(
                name: "IX_CountryMovie_MoviesId",
                table: "CountryMovie",
                newName: "IX_CountryMovie_MoviesID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Country",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovie_Country_CountriesID",
                table: "CountryMovie",
                column: "CountriesID",
                principalTable: "Country",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovie_Movie_MoviesID",
                table: "CountryMovie",
                column: "MoviesID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genre_GenresID",
                table: "GenreMovie",
                column: "GenresID",
                principalTable: "Genre",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Movie_MoviesID",
                table: "GenreMovie",
                column: "MoviesID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
