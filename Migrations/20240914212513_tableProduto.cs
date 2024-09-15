using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstOne.Migrations
{
    /// <inheritdoc />
    public partial class tableProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Empregados");

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Preco = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Estoque = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CategoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.ProdutoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeDepartamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Empregados",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DepartamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FotoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregados", x => x.EmpId);
                });
        }
    }
}
