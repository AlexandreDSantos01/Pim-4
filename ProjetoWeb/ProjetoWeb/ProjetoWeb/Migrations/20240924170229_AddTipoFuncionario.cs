using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Funcionarios");
        }
    }
}
