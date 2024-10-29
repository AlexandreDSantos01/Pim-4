using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWeb.Migrations
{
    /// <inheritdoc />
    public partial class ApiMobile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NRua = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Estoques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DColheita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DRegistroProducao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimativaProducao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorNutritivo = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Estoques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Financeiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDespesa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorLucro = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Financeiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NRua = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Produtos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Producoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estimativa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Producoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NRua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulogar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    EstoqueId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Vendas_tb_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tb_Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_Vendas_tb_Estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "tb_Estoques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Despesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Produto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Despesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Despesas_tb_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "tb_Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Despesas_FornecedorId",
                table: "tb_Despesas",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Vendas_ClienteId",
                table: "tb_Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Vendas_EstoqueId",
                table: "tb_Vendas",
                column: "EstoqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Despesas");

            migrationBuilder.DropTable(
                name: "tb_Financeiros");

            migrationBuilder.DropTable(
                name: "tb_Producoes");

            migrationBuilder.DropTable(
                name: "tb_Usuarios");

            migrationBuilder.DropTable(
                name: "tb_Vendas");

            migrationBuilder.DropTable(
                name: "tb_Fornecedores");

            migrationBuilder.DropTable(
                name: "tb_Clientes");

            migrationBuilder.DropTable(
                name: "tb_Estoques");
        }
    }
}
