using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT5032_Assignment_2.Data.Migrations
{
    public partial class OrganisationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganisationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Org_URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dateline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Org_Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Project_Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Target_Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationDetails_UserId",
                table: "OrganisationDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationDetails");
        }
    }
}
