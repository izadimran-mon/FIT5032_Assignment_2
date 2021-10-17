using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT5032_Assignment_2.Data.Migrations
{
    public partial class NFTsBought : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NFTsBought",
                columns: table => new
                {
                    Tx_Hash = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Buyer_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    NFT_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sold_For = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFTsBought", x => x.Tx_Hash);
                    table.ForeignKey(
                        name: "FK_NFTsBought_AspNetUsers_OrgId",
                        column: x => x.OrgId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NFTsBought_OrgId",
                table: "NFTsBought",
                column: "OrgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NFTsBought");
        }
    }
}
