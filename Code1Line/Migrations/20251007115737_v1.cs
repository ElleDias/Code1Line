using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code1Line.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    IdEquipe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.IdEquipe);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    IdFuncao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.IdFuncao);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    IdMensagens = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.IdMensagens);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDepartamento",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDepartamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDepartamento", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_UsuarioDepartamento_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEquipe",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEquipe = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEquipe", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_UsuarioEquipe_Equipe_IdEquipe",
                        column: x => x.IdEquipe,
                        principalTable: "Equipe",
                        principalColumn: "IdEquipe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioFuncao",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFuncao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dataInicio = table.Column<int>(type: "int", nullable: false),
                    dataFim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioFuncao", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_UsuarioFuncao_Funcao_IdFuncao",
                        column: x => x.IdFuncao,
                        principalTable: "Funcao",
                        principalColumn: "IdFuncao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acessos",
                columns: table => new
                {
                    IdAcessos = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimoAcesso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessos", x => x.IdAcessos);
                    table.ForeignKey(
                        name: "FK_Acessos_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    IdAtividades = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.IdAtividades);
                    table.ForeignKey(
                        name: "FK_Atividades_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metrica",
                columns: table => new
                {
                    IdMetrica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorasProdutivas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorasInprodutivas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorasNeutras = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrica", x => x.IdMetrica);
                    table.ForeignKey(
                        name: "FK_Metrica_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitoramento",
                columns: table => new
                {
                    IdMonitoramento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TempoAtivo = table.Column<TimeSpan>(type: "time", nullable: false),
                    TempoInativo = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoramento", x => x.IdMonitoramento);
                    table.ForeignKey(
                        name: "FK_Monitoramento_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outlier",
                columns: table => new
                {
                    IdOutlier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlier", x => x.IdOutlier);
                    table.ForeignKey(
                        name: "FK_Outlier_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_IdUsuario",
                table: "Acessos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_IdUsuario",
                table: "Atividades",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Metrica_IdUsuario",
                table: "Metrica",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoramento_IdUsuario",
                table: "Monitoramento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Outlier_IdUsuario",
                table: "Outlier",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDepartamento_IdDepartamento",
                table: "UsuarioDepartamento",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEquipe_IdEquipe",
                table: "UsuarioEquipe",
                column: "IdEquipe");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioFuncao_IdFuncao",
                table: "UsuarioFuncao",
                column: "IdFuncao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Metrica");

            migrationBuilder.DropTable(
                name: "Monitoramento");

            migrationBuilder.DropTable(
                name: "Outlier");

            migrationBuilder.DropTable(
                name: "UsuarioDepartamento");

            migrationBuilder.DropTable(
                name: "UsuarioEquipe");

            migrationBuilder.DropTable(
                name: "UsuarioFuncao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Funcao");
        }
    }
}
