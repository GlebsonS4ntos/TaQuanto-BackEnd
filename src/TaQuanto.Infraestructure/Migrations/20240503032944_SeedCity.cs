using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaQuanto.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO City (Id, Name, StateId, CreatAt) SELECT '{Guid.NewGuid()}', 'Barra Bonita', s.Id, " +
                $"'{DateTime.Now}' FROM State s WHERE s.UF = 'SP'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM City WHERE City.Name = 'Barra Bonita' AND City.StateId IN " +
                "(SELECT s.Id FROM State s WHERE s.UF = 'SP')");
        }
    }
}
