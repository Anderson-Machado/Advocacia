using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace APIA.Migrations
{
  public partial class ADVC : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Empresas",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            Cnpj = table.Column<int>(nullable: false),
            Estado = table.Column<string>(nullable: true),
            Nome = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Empresas", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Processos",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            DataInicio = table.Column<DateTime>(nullable: false),
            Estado = table.Column<string>(nullable: true),
            IdEmpresa = table.Column<int>(nullable: false),
            IsAtivo = table.Column<bool>(nullable: false),
            NumeroProcesso = table.Column<string>(nullable: true),
            Valor = table.Column<decimal>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Processos", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Empresas");

      migrationBuilder.DropTable(
          name: "Processos");
    }
  }
}
