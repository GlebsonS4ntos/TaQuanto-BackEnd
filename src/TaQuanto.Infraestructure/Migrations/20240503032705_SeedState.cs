using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaQuanto.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Name", "UF", "CreatAt" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "São Paulo", "SP", DateTime.Now},
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "State",
                keyColumn: "UF",
                keyValues: new object[]
                {
                    "SP"
                });
        }
    }
}
