using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstOne.Migrations
{
    /// <inheritdoc />
    public partial class alterTableProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_produtos",
                table: "produtos");

            migrationBuilder.RenameTable(
                name: "produtos",
                newName: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "PrecoProduto");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produtos",
                newName: "NomeProduto");

            migrationBuilder.RenameColumn(
                name: "Estoque",
                table: "Produtos",
                newName: "EstoqueProduto");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produtos",
                newName: "DescricaoProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "produtos");

            migrationBuilder.RenameColumn(
                name: "PrecoProduto",
                table: "produtos",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "NomeProduto",
                table: "produtos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EstoqueProduto",
                table: "produtos",
                newName: "Estoque");

            migrationBuilder.RenameColumn(
                name: "DescricaoProduto",
                table: "produtos",
                newName: "Descricao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produtos",
                table: "produtos",
                column: "ProdutoId");
        }
    }
}
