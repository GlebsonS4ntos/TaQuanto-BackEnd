using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaQuanto.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Retrict_Delete_Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Establishment_EstablishmentId",
                table: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Establishment_EstablishmentId",
                table: "Product",
                column: "EstablishmentId",
                principalTable: "Establishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Establishment_EstablishmentId",
                table: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Establishment_EstablishmentId",
                table: "Product",
                column: "EstablishmentId",
                principalTable: "Establishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
