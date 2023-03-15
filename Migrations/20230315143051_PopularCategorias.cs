using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanches.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Frutas da estação', 'Frutas da estação')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Natural', 'Lanche feito com ingredientes naturais e integrais')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Normal', 'Lanches feito com ingredientes normais')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
