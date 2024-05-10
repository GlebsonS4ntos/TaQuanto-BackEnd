using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaQuanto.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Properties_ImgPublicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePublicId",
                table: "Product",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePublicId",
                table: "Establishment",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePublicId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImagePublicId",
                table: "Establishment");
        }
    }
}
