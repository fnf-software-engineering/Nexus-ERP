using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderEngine.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarProdutosEstoqueTiposMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "est_tipos_movimentacao",
                columns: table => new
                {
                    id_tipo_movimentacao = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tipo = table.Column<string>(type: "char(1)", nullable: false),
                    atualiza_custo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    movimenta_estoque = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_est_tipos_movimentacao", x => x.id_tipo_movimentacao);
                });

            migrationBuilder.CreateTable(
                name: "prod_grupos",
                columns: table => new
                {
                    id_grupo = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod_grupos", x => x.id_grupo);
                });

            migrationBuilder.CreateTable(
                name: "prod_unidades_medida",
                columns: table => new
                {
                    id_unidade = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    sigla = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    casas_decimais = table.Column<int>(type: "integer", nullable: false, defaultValue: 2),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod_unidades_medida", x => x.id_unidade);
                });

            migrationBuilder.CreateTable(
                name: "prod_produtos",
                columns: table => new
                {
                    id_produto = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    descricao_reduzida = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    id_grupo = table.Column<Guid>(type: "uuid", nullable: true),
                    id_unidade = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_barras = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    referencia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    controla_estoque = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    permite_venda = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    permite_compra = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    preco_venda = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    custo_atual = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    custo_medio = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    estoque_minimo = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    estoque_maximo = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    peso_liquido = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: true),
                    peso_bruto = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prod_produtos", x => x.id_produto);
                    table.ForeignKey(
                        name: "FK_prod_produtos_prod_grupos_id_grupo",
                        column: x => x.id_grupo,
                        principalTable: "prod_grupos",
                        principalColumn: "id_grupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prod_produtos_prod_unidades_medida_id_unidade",
                        column: x => x.id_unidade,
                        principalTable: "prod_unidades_medida",
                        principalColumn: "id_unidade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "est_estoques",
                columns: table => new
                {
                    id_estoque = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    id_filial = table.Column<Guid>(type: "uuid", nullable: false),
                    id_produto = table.Column<Guid>(type: "uuid", nullable: false),
                    quantidade_atual = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    quantidade_reservada = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    custo_medio = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    data_ultima_mov = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_est_estoques", x => x.id_estoque);
                    table.ForeignKey(
                        name: "FK_est_estoques_erp_empresas_id_empresa",
                        column: x => x.id_empresa,
                        principalTable: "erp_empresas",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_est_estoques_erp_filiais_id_filial",
                        column: x => x.id_filial,
                        principalTable: "erp_filiais",
                        principalColumn: "id_filial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_est_estoques_prod_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "prod_produtos",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_est_estoques_id_filial",
                table: "est_estoques",
                column: "id_filial");

            migrationBuilder.CreateIndex(
                name: "IX_est_estoques_id_produto",
                table: "est_estoques",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "ux_estoque_empresa_filial_produto",
                table: "est_estoques",
                columns: new[] { "id_empresa", "id_filial", "id_produto" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prod_produtos_id_grupo",
                table: "prod_produtos",
                column: "id_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_prod_produtos_id_unidade",
                table: "prod_produtos",
                column: "id_unidade");

            migrationBuilder.CreateIndex(
                name: "ix_produto_descricao",
                table: "prod_produtos",
                column: "descricao");

            migrationBuilder.CreateIndex(
                name: "ux_produto_codigo",
                table: "prod_produtos",
                column: "codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "est_estoques");

            migrationBuilder.DropTable(
                name: "est_tipos_movimentacao");

            migrationBuilder.DropTable(
                name: "prod_produtos");

            migrationBuilder.DropTable(
                name: "prod_grupos");

            migrationBuilder.DropTable(
                name: "prod_unidades_medida");
        }
    }
}
