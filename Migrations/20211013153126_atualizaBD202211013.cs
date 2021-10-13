using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDespesa5.Migrations
{
    public partial class atualizaBD202211013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomedespesa = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomereceita = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimentosDR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Usario = table.Column<int>(type: "int", nullable: false),
                    Id_Despesa = table.Column<int>(type: "int", nullable: false),
                    Id_Receita = table.Column<int>(type: "int", nullable: false),
                    Data_MovimentosDR = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_Des = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desc_Despesa = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Repete = table.Column<bool>(type: "bit", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentosDR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentosDR_Despesa_Id_Usario",
                        column: x => x.Id_Usario,
                        principalTable: "Despesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentosDR_Id_Usario",
                table: "MovimentosDR",
                column: "Id_Usario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentosDR");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Despesa");
        }
    }
}
