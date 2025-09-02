using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XenoByte.Migrations
{
    /// <inheritdoc />
    public partial class AddRansomwareReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RansomwareReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BitcoinAddresses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Demand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentScreenshotPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RansomNotePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RansomwareReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RansomwareReports_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RansomwareReports_UserId",
                table: "RansomwareReports",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RansomwareReports");
        }
    }
}
