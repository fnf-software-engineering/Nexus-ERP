using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderEngine.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoSegurancaUsuariosPerfisPermissoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "seg_perfis",
                columns: table => new
                {
                    id_perfil = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descricao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    administrador = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg_perfis", x => x.id_perfil);
                });

            migrationBuilder.CreateTable(
                name: "seg_permissoes",
                columns: table => new
                {
                    id_permissao = table.Column<Guid>(type: "uuid", nullable: false),
                    modulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    recurso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    acao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg_permissoes", x => x.id_permissao);
                });

            migrationBuilder.CreateTable(
                name: "seg_usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    senha_hash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    bloqueado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    data_ultimo_login = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg_usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "seg_perfil_permissoes",
                columns: table => new
                {
                    id_perfil = table.Column<Guid>(type: "uuid", nullable: false),
                    id_permissao = table.Column<Guid>(type: "uuid", nullable: false),
                    permitido = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg_perfil_permissoes", x => new { x.id_perfil, x.id_permissao });
                    table.ForeignKey(
                        name: "FK_seg_perfil_permissoes_seg_perfis_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "seg_perfis",
                        principalColumn: "id_perfil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_seg_perfil_permissoes_seg_permissoes_id_permissao",
                        column: x => x.id_permissao,
                        principalTable: "seg_permissoes",
                        principalColumn: "id_permissao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seg_usuario_filiais",
                columns: table => new
                {
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    id_filial = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg_usuario_filiais", x => new { x.id_usuario, x.id_empresa, x.id_filial });
                    table.ForeignKey(
                        name: "FK_seg_usuario_filiais_erp_empresas_id_empresa",
                        column: x => x.id_empresa,
                        principalTable: "erp_empresas",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_seg_usuario_filiais_erp_filiais_id_filial",
                        column: x => x.id_filial,
                        principalTable: "erp_filiais",
                        principalColumn: "id_filial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_seg_usuario_filiais_seg_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "seg_usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "seg_usuario_perfis",
                columns: table => new
                {
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: false),
                    id_perfil = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg_usuario_perfis", x => new { x.id_usuario, x.id_perfil });
                    table.ForeignKey(
                        name: "FK_seg_usuario_perfis_seg_perfis_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "seg_perfis",
                        principalColumn: "id_perfil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_seg_usuario_perfis_seg_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "seg_usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_seg_perfil_permissoes_id_permissao",
                table: "seg_perfil_permissoes",
                column: "id_permissao");

            migrationBuilder.CreateIndex(
                name: "IX_seg_usuario_filiais_id_empresa",
                table: "seg_usuario_filiais",
                column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_seg_usuario_filiais_id_filial",
                table: "seg_usuario_filiais",
                column: "id_filial");

            migrationBuilder.CreateIndex(
                name: "IX_seg_usuario_perfis_id_perfil",
                table: "seg_usuario_perfis",
                column: "id_perfil");

            migrationBuilder.CreateIndex(
                name: "ux_usuario_email",
                table: "seg_usuarios",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_usuario_login",
                table: "seg_usuarios",
                column: "login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "seg_perfil_permissoes");

            migrationBuilder.DropTable(
                name: "seg_usuario_filiais");

            migrationBuilder.DropTable(
                name: "seg_usuario_perfis");

            migrationBuilder.DropTable(
                name: "seg_permissoes");

            migrationBuilder.DropTable(
                name: "seg_perfis");

            migrationBuilder.DropTable(
                name: "seg_usuarios");
        }
    }
}
