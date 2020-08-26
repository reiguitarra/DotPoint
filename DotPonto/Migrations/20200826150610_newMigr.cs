using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotPonto.Migrations
{
    public partial class newMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(nullable: true),
                    EmpEndereco = table.Column<string>(nullable: true),
                    EmpEndNumero = table.Column<string>(nullable: true),
                    EmpEndBairro = table.Column<string>(nullable: true),
                    EmpEndCidade = table.Column<string>(nullable: true),
                    EmpEndUF = table.Column<string>(nullable: true),
                    EmpEndCEP = table.Column<string>(nullable: true),
                    CNAE = table.Column<string>(nullable: true),
                    InscricaoMunicipal = table.Column<string>(nullable: true),
                    InscricaoEstadual = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotacao",
                columns: table => new
                {
                    LotId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LotNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotacao", x => x.LotId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Usuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuId);
                });

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(nullable: true),
                    EmpEndereco = table.Column<string>(nullable: true),
                    EmpEndNumero = table.Column<string>(nullable: true),
                    EmpEndBairro = table.Column<string>(nullable: true),
                    EmpEndCidade = table.Column<string>(nullable: true),
                    EmpEndUF = table.Column<string>(nullable: true),
                    EmpEndCEP = table.Column<string>(nullable: true),
                    CNAE = table.Column<string>(nullable: true),
                    InscricaoMunicipal = table.Column<string>(nullable: true),
                    InscricaoEstadual = table.Column<string>(nullable: true),
                    EmpresasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filiais_Empresas_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Mae = table.Column<string>(nullable: true),
                    Pai = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    PIS = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    FuEndRua = table.Column<string>(nullable: true),
                    FuEndNumero = table.Column<string>(nullable: true),
                    FuEndBairro = table.Column<string>(nullable: true),
                    FuEndCidade = table.Column<string>(nullable: true),
                    FuEndUF = table.Column<string>(nullable: true),
                    EmpresasId = table.Column<int>(nullable: false),
                    FiliaisId = table.Column<int>(nullable: false),
                    LotacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Empresas_EmpresasId",
                        column: x => x.EmpresasId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Filiais_FiliaisId",
                        column: x => x.FiliaisId,
                        principalTable: "Filiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Lotacao_LotacaoId",
                        column: x => x.LotacaoId,
                        principalTable: "Lotacao",
                        principalColumn: "LotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_EmpresasId",
                table: "Filiais",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmpresasId",
                table: "Funcionarios",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FiliaisId",
                table: "Funcionarios",
                column: "FiliaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_LotacaoId",
                table: "Funcionarios",
                column: "LotacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropTable(
                name: "Lotacao");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
