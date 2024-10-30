using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnchapaxiAriel_ExamenP1.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnchapaxiModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MoneyInTheBank = table.Column<float>(type: "real", nullable: false),
                    IsStudent = table.Column<bool>(type: "bit", nullable: false),
                    BirthDay = table.Column<DateOnly>(type: "date", nullable: false),
                    idPhone = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnchapaxiModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnchapaxiModel_PhoneModel_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "PhoneModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnchapaxiModel_PhoneId",
                table: "AnchapaxiModel",
                column: "PhoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnchapaxiModel");

            migrationBuilder.DropTable(
                name: "PhoneModel");
        }
    }
}
