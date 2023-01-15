using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FMECA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FMECA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FMECANumber = table.Column<string>(type: "text", nullable: false),
                    RefrenceFMECANumber = table.Column<string>(type: "text", nullable: true),
                    IsCriticalRisk = table.Column<bool>(type: "boolean", nullable: false),
                    FMECAType = table.Column<int>(type: "integer", nullable: false),
                    FMECAStatus = table.Column<int>(type: "integer", nullable: false),
                    TopLevelPartNumber = table.Column<string>(type: "text", nullable: false),
                    TopLevelPartDescription = table.Column<string>(type: "text", nullable: false),
                    ProcessName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Attachments = table.Column<string>(type: "text", nullable: false),
                    ProjectID = table.Column<string>(type: "text", nullable: false),
                    ProjectName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProcessFMECAType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMECA", x => new { x.ID, x.FMECANumber });
                });

            migrationBuilder.CreateTable(
                name: "FMECAReport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<string>(type: "text", nullable: false),
                    ReportName = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    ReportColumn = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMECAReport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PartRiskColumnDefinition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColumnName = table.Column<string>(type: "text", nullable: false),
                    FMECAType = table.Column<int>(type: "integer", nullable: false),
                    Header = table.Column<string>(type: "text", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartRiskColumnDefinition", x => new { x.ID, x.ColumnName, x.FMECAType });
                });

            migrationBuilder.CreateTable(
                name: "PartRisk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FMECANumber = table.Column<string>(type: "text", nullable: false),
                    SequenceId = table.Column<int>(type: "integer", nullable: false),
                    PartLevel = table.Column<int>(type: "integer", nullable: false),
                    PartNumber = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FMECAID = table.Column<int>(type: "integer", nullable: true),
                    FMECANumber1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartRisk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartRisk_FMECA_FMECAID_FMECANumber1",
                        columns: x => new { x.FMECAID, x.FMECANumber1 },
                        principalTable: "FMECA",
                        principalColumns: new[] { "ID", "FMECANumber" });
                });

            migrationBuilder.CreateTable(
                name: "ProcessRisk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FMECANumber = table.Column<string>(type: "text", nullable: false),
                    SequenceID = table.Column<int>(type: "integer", nullable: false),
                    ProcessLevel = table.Column<int>(type: "integer", nullable: false),
                    ProcessId = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FMECAID = table.Column<int>(type: "integer", nullable: true),
                    FMECANumber1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRisk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProcessRisk_FMECA_FMECAID_FMECANumber1",
                        columns: x => new { x.FMECAID, x.FMECANumber1 },
                        principalTable: "FMECA",
                        principalColumns: new[] { "ID", "FMECANumber" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartRisk_FMECAID_FMECANumber1",
                table: "PartRisk",
                columns: new[] { "FMECAID", "FMECANumber1" });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRisk_FMECAID_FMECANumber1",
                table: "ProcessRisk",
                columns: new[] { "FMECAID", "FMECANumber1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMECAReport");

            migrationBuilder.DropTable(
                name: "PartRisk");

            migrationBuilder.DropTable(
                name: "PartRiskColumnDefinition");

            migrationBuilder.DropTable(
                name: "ProcessRisk");

            migrationBuilder.DropTable(
                name: "FMECA");
        }
    }
}
