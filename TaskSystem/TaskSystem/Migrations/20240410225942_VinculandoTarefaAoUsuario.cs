using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSystem.Migrations
{
    /// <inheritdoc />
    public partial class VinculandoTarefaAoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_usuarioId",
                table: "Tarefas",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioId",
                table: "Tarefas",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioId",
                table: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_usuarioId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Tarefas");
        }
    }
}
