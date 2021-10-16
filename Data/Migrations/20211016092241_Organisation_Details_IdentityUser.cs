using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT5032_Assignment_2.Data.Migrations
{
    public partial class Organisation_Details_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrganisationDetails_UserId",
                table: "OrganisationDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationDetails_AspNetUsers_UserId",
                table: "OrganisationDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationDetails_AspNetUsers_UserId",
                table: "OrganisationDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrganisationDetails_UserId",
                table: "OrganisationDetails");
        }
    }
}
