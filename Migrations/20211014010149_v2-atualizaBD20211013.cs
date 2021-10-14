using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDespesa5.Migrations
{
    public partial class v2atualizaBD20211013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentosDR_Despesa_Id_Usario",
                table: "MovimentosDR");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "Receita",
                newName: "Id_Usuario");

            migrationBuilder.RenameColumn(
                name: "Id_Usario",
                table: "MovimentosDR",
                newName: "Id_Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentosDR_Id_Usario",
                table: "MovimentosDR",
                newName: "IX_MovimentosDR_Id_Usuario");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "Despesa",
                newName: "Id_Usuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Receita",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "MovimentosDR",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Despesa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Usuario = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receita_UsuariosId",
                table: "Receita",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentosDR_UsuariosId",
                table: "MovimentosDR",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_UsuariosId",
                table: "Despesa",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_Usuarios_UsuariosId",
                table: "Despesa",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentosDR_Despesa_Id_Usuario",
                table: "MovimentosDR",
                column: "Id_Usuario",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentosDR_Usuarios_UsuariosId",
                table: "MovimentosDR",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Usuarios_UsuariosId",
                table: "Receita",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_Usuarios_UsuariosId",
                table: "Despesa");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentosDR_Despesa_Id_Usuario",
                table: "MovimentosDR");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimentosDR_Usuarios_UsuariosId",
                table: "MovimentosDR");

            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Usuarios_UsuariosId",
                table: "Receita");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Receita_UsuariosId",
                table: "Receita");

            migrationBuilder.DropIndex(
                name: "IX_MovimentosDR_UsuariosId",
                table: "MovimentosDR");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_UsuariosId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "MovimentosDR");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Despesa");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "Receita",
                newName: "Id_User");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "MovimentosDR",
                newName: "Id_Usario");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentosDR_Id_Usuario",
                table: "MovimentosDR",
                newName: "IX_MovimentosDR_Id_Usario");

            migrationBuilder.RenameColumn(
                name: "Id_Usuario",
                table: "Despesa",
                newName: "Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentosDR_Despesa_Id_Usario",
                table: "MovimentosDR",
                column: "Id_Usario",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
