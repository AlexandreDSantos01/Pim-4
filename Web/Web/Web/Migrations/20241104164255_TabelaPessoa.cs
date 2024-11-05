using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Fornecedor_FornecedorId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Estoque_EstoqueId",
                table: "Venda");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venda",
                table: "Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producao",
                table: "Producao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Financeiro",
                table: "Financeiro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Despesa");

            migrationBuilder.RenameTable(
                name: "Venda",
                newName: "tb_Venda");

            migrationBuilder.RenameTable(
                name: "Producao",
                newName: "tb_Producao");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "tb_Fornecedor");

            migrationBuilder.RenameTable(
                name: "Financeiro",
                newName: "tb_Financeiro");

            migrationBuilder.RenameTable(
                name: "Estoque",
                newName: "tb_Estoque");

            migrationBuilder.RenameTable(
                name: "Despesa",
                newName: "tb_Despesa");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "tb_Pessoa");

            migrationBuilder.RenameColumn(
                name: "EstoqueId",
                table: "tb_Venda",
                newName: "pk_idEstoque");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "tb_Venda",
                newName: "pk_idCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_EstoqueId",
                table: "tb_Venda",
                newName: "IX_tb_Venda_pk_idEstoque");

            migrationBuilder.RenameIndex(
                name: "IX_Venda_ClienteId",
                table: "tb_Venda",
                newName: "IX_tb_Venda_pk_idCliente");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "tb_Despesa",
                newName: "pk_idFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_Despesa_FornecedorId",
                table: "tb_Despesa",
                newName: "IX_tb_Despesa_pk_idFornecedor");

            migrationBuilder.AlterColumn<string>(
                name: "Ulogar",
                table: "tb_Pessoa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TipoUsuario",
                table: "tb_Pessoa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "tb_Pessoa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NRua",
                table: "tb_Pessoa",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "tb_Pessoa",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Venda",
                table: "tb_Venda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Producao",
                table: "tb_Producao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Fornecedor",
                table: "tb_Fornecedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Financeiro",
                table: "tb_Financeiro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Estoque",
                table: "tb_Estoque",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Despesa",
                table: "tb_Despesa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Pessoa",
                table: "tb_Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Despesa_tb_Fornecedor_pk_idFornecedor",
                table: "tb_Despesa",
                column: "pk_idFornecedor",
                principalTable: "tb_Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Venda_tb_Estoque_pk_idEstoque",
                table: "tb_Venda",
                column: "pk_idEstoque",
                principalTable: "tb_Estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Venda_tb_Pessoa_pk_idCliente",
                table: "tb_Venda",
                column: "pk_idCliente",
                principalTable: "tb_Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Despesa_tb_Fornecedor_pk_idFornecedor",
                table: "tb_Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_Venda_tb_Estoque_pk_idEstoque",
                table: "tb_Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_Venda_tb_Pessoa_pk_idCliente",
                table: "tb_Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Venda",
                table: "tb_Venda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Producao",
                table: "tb_Producao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Fornecedor",
                table: "tb_Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Financeiro",
                table: "tb_Financeiro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Estoque",
                table: "tb_Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Despesa",
                table: "tb_Despesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Pessoa",
                table: "tb_Pessoa");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "tb_Pessoa");

            migrationBuilder.RenameTable(
                name: "tb_Venda",
                newName: "Venda");

            migrationBuilder.RenameTable(
                name: "tb_Producao",
                newName: "Producao");

            migrationBuilder.RenameTable(
                name: "tb_Fornecedor",
                newName: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "tb_Financeiro",
                newName: "Financeiro");

            migrationBuilder.RenameTable(
                name: "tb_Estoque",
                newName: "Estoque");

            migrationBuilder.RenameTable(
                name: "tb_Despesa",
                newName: "Despesa");

            migrationBuilder.RenameTable(
                name: "tb_Pessoa",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "pk_idEstoque",
                table: "Venda",
                newName: "EstoqueId");

            migrationBuilder.RenameColumn(
                name: "pk_idCliente",
                table: "Venda",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_Venda_pk_idEstoque",
                table: "Venda",
                newName: "IX_Venda_EstoqueId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_Venda_pk_idCliente",
                table: "Venda",
                newName: "IX_Venda_ClienteId");

            migrationBuilder.RenameColumn(
                name: "pk_idFornecedor",
                table: "Despesa",
                newName: "FornecedorId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_Despesa_pk_idFornecedor",
                table: "Despesa",
                newName: "IX_Despesa_FornecedorId");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Despesa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ulogar",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoUsuario",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NRua",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venda",
                table: "Venda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producao",
                table: "Producao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Financeiro",
                table: "Financeiro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NRua = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Fornecedor_FornecedorId",
                table: "Despesa",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Estoque_EstoqueId",
                table: "Venda",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
