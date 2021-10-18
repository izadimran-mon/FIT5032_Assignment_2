using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT5032_Assignment_2.Data.Migrations
{
    public partial class NFTsDonated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NFTsDonated",
                columns: table => new
                {
                    Tx_Hash = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Donor_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    NFT_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bought_Tx = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    List_Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFTsDonated", x => x.Tx_Hash);
                    table.ForeignKey(
                        name: "FK_NFTsDonated_AspNetUsers_OrgId",
                        column: x => x.OrgId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NFTsDonated_NFTsBought_Bought_Tx",
                        column: x => x.Bought_Tx,
                        principalTable: "NFTsBought",
                        principalColumn: "Tx_Hash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NFTsDonated_Bought_Tx",
                table: "NFTsDonated",
                column: "Bought_Tx");

            migrationBuilder.CreateIndex(
                name: "IX_NFTsDonated_OrgId",
                table: "NFTsDonated",
                column: "OrgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NFTsDonated");
        }
    }
}
