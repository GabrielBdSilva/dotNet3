using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstOne.Migrations
{
    /// <inheritdoc />
    public partial class createTableCarrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Produtos",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    CarrinhoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.CarrinhoId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Produtos");
        }
    }
}
