using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jobapplicationproject.Migrations
{
    public partial class ResetData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(maxLength: 25, nullable: false),
                    SalaryFrom = table.Column<decimal>(nullable: true),
                    SalaryTo = table.Column<decimal>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobOfferId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    ContactAgreement = table.Column<bool>(nullable: false),
                    CvUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Auchan" },
                    { 2, "Tesco" },
                    { 3, "Biedronka" },
                    { 4, "Lewiatan" },
                    { 5, "Żabka" },
                    { 6, "Carrefour" }
                });

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "CompanyId", "Created", "Description", "JobTitle", "Location", "SalaryFrom", "SalaryTo", "ValidUntil" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nice work, I recommend", "Frontend", "Warsaw", 3000m, 5000m, new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fruit mondays", "Backend", "Warsaw", 4500m, 6500m, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very dynamic team", "On dish", "Grojec", 2200m, 3200m, new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable armchair", "Cashier", "Piaseczno", 2200m, 3200m, new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easy job", "Warehouseman", "Piaseczno", 2200m, 3200m, new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Driving skills required", "Forklift operator", "Radom", 3500m, 4500m, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karate and judo skills required. Gun license required", "Security guard", "Lublin", 3000m, 4000m, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "ContactAgreement", "CvUrl", "EmailAddress", "FirstName", "JobOfferId", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, true, "https://www.cv.com/goreckia/", "goreckia@gmail.com", "Arkadiusz", 1, "Górecki", "731327437" },
                    { 2, false, "https://www.cv.com/cesarskim/", "cesarskim@gmail.com", "Maciej", 1, "Cesarski", "123123123" },
                    { 3, true, "https://www.cv.com/johansons/", "johansons@gmail.com", "Scarlett", 1, "Johanson", "420690000" },
                    { 4, true, "https://www.cv.com/sparrowj/", "sparrowj@gmail.com", "Jack", 2, "Sparrow", "120690000" },
                    { 5, true, "https://www.cv.com/turnerw/", "turnerw@gmail.com", "Will", 2, "Turner", "111333222" },
                    { 6, true, "https://www.cv.com/starkt/", "starkt@gmail.com", "Tony", 3, "Stark", "12346789" },
                    { 7, false, "https://www.cv.com/bagginsf/", "bagginsf@gmail.com", "Frodo", 3, "Baggins", "789789789" },
                    { 8, true, "https://www.cv.com/cruiset/", "cruiset@gmail.com", "Tom", 3, "Cruise", "675435098" },
                    { 9, true, "https://www.cv.com/rabbitj/", "rabbitj@gmail.com", "Jojo", 4, "Rabbit", "888888888" },
                    { 10, false, "https://www.cv.com/joestarj/", "joestarj@gmail.com", "Joseph", 5, "Joestar", "123890456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobOfferId",
                table: "JobApplications",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
