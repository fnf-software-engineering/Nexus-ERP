using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderEngine.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasLogsEParametros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aud_logs",
                columns: table => new
                {
                    id_log = table.Column<Guid>(type: "uuid", nullable: false),
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: true),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: true),
                    id_filial = table.Column<Guid>(type: "uuid", nullable: true),
                    data_hora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    modulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    entidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    id_registro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    acao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ip_origem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_agent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    sucesso = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    mensagem_erro = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aud_logs", x => x.id_log);
                    table.ForeignKey(
                        name: "FK_aud_logs_seg_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "seg_usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "sis_parametros",
                columns: table => new
                {
                    id_parametro = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: true),
                    id_filial = table.Column<Guid>(type: "uuid", nullable: true),
                    chave = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    valor = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    tipo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false, defaultValue: "STRING"),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sis_parametros", x => x.id_parametro);
                    table.ForeignKey(
                        name: "FK_sis_parametros_erp_empresas_id_empresa",
                        column: x => x.id_empresa,
                        principalTable: "erp_empresas",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_sis_parametros_erp_filiais_id_filial",
                        column: x => x.id_filial,
                        principalTable: "erp_filiais",
                        principalColumn: "id_filial",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "aud_log_detalhes",
                columns: table => new
                {
                    id_log_detalhe = table.Column<Guid>(type: "uuid", nullable: false),
                    id_log = table.Column<Guid>(type: "uuid", nullable: false),
                    campo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    valor_anterior = table.Column<string>(type: "text", nullable: true),
                    valor_novo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aud_log_detalhes", x => x.id_log_detalhe);
                    table.ForeignKey(
                        name: "FK_aud_log_detalhes_aud_logs_id_log",
                        column: x => x.id_log,
                        principalTable: "aud_logs",
                        principalColumn: "id_log",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aud_log_detalhes_id_log",
                table: "aud_log_detalhes",
                column: "id_log");

            migrationBuilder.CreateIndex(
                name: "IX_aud_logs_id_usuario",
                table: "aud_logs",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_sis_parametros_id_empresa",
                table: "sis_parametros",
                column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_sis_parametros_id_filial",
                table: "sis_parametros",
                column: "id_filial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aud_log_detalhes");

            migrationBuilder.DropTable(
                name: "sis_parametros");

            migrationBuilder.DropTable(
                name: "aud_logs");
        }
    }
}
