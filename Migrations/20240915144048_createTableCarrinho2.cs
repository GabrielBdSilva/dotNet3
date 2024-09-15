using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstOne.Migrations
{
    /// <inheritdoc />
    public partial class createTableCarrinho2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "Produtos",
                table: "Carrinhos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Produtos",
                table: "Carrinhos");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Produtos",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos",
                column: "CarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "CarrinhoId");
        }
    }
}
