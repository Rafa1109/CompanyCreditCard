using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyCreditCard.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CC_CLIENTE",
                columns: table => new
                {
                    Cod_Cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: true),
                    Endereco = table.Column<string>(type: "varchar(60)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: true),
                    Municipio = table.Column<string>(type: "varchar(50)", nullable: true),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: true),
                    Login = table.Column<string>(type: "varchar(30)", nullable: true),
                    Senha = table.Column<string>(type: "varchar(60)", nullable: true),
                    Email = table.Column<string>(type: "varchar(80)", nullable: true),
                    DiaVencimentoCartao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CC_CLIENTE", x => x.Cod_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "TB_CC_COMPRA",
                columns: table => new
                {
                    CodCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCliente = table.Column<int>(nullable: false),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantParcelas = table.Column<int>(nullable: false),
                    DescrExtrato = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CC_COMPRA", x => x.CodCompra);
                    table.ForeignKey(
                        name: "FK_TB_CC_COMPRA_TB_CC_CLIENTE_CodCliente",
                        column: x => x.CodCliente,
                        principalTable: "TB_CC_CLIENTE",
                        principalColumn: "Cod_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CC_FATURA",
                columns: table => new
                {
                    CodFatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCliente = table.Column<int>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    ValorFatura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPagto = table.Column<DateTime>(nullable: true),
                    CodigoBarra = table.Column<string>(type: "varchar(47)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CC_FATURA", x => x.CodFatura);
                    table.ForeignKey(
                        name: "FK_TB_CC_FATURA_TB_CC_CLIENTE_CodCliente",
                        column: x => x.CodCliente,
                        principalTable: "TB_CC_CLIENTE",
                        principalColumn: "Cod_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CC_PARCELA",
                columns: table => new
                {
                    CodParcela = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodCompra = table.Column<int>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CodFatura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CC_PARCELA", x => x.CodParcela);
                    table.ForeignKey(
                        name: "FK_TB_CC_PARCELA_TB_CC_COMPRA_CodCompra",
                        column: x => x.CodCompra,
                        principalTable: "TB_CC_COMPRA",
                        principalColumn: "CodCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CC_PARCELA_TB_CC_FATURA_CodFatura",
                        column: x => x.CodFatura,
                        principalTable: "TB_CC_FATURA",
                        principalColumn: "CodFatura",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CC_COMPRA_CodCliente",
                table: "TB_CC_COMPRA",
                column: "CodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CC_FATURA_CodCliente",
                table: "TB_CC_FATURA",
                column: "CodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CC_PARCELA_CodCompra",
                table: "TB_CC_PARCELA",
                column: "CodCompra");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CC_PARCELA_CodFatura",
                table: "TB_CC_PARCELA",
                column: "CodFatura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CC_PARCELA");

            migrationBuilder.DropTable(
                name: "TB_CC_COMPRA");

            migrationBuilder.DropTable(
                name: "TB_CC_FATURA");

            migrationBuilder.DropTable(
                name: "TB_CC_CLIENTE");
        }
    }
}
