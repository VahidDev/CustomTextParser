using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialInstitutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettlementCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialInstitutionId = table.Column<int>(type: "int", nullable: true),
                    FXSettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReconciliationFileID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionCurrency = table.Column<int>(type: "int", nullable: false),
                    ReconciliationCurrency = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_FinancialInstitutions_FinancialInstitutionId",
                        column: x => x.FinancialInstitutionId,
                        principalTable: "FinancialInstitutions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SettlementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettlementCategoryId = table.Column<int>(type: "int", nullable: true),
                    TransactionAmountCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionAmountDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReconciliationAmntCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReconciliationAmntDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeAmountCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeAmountDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountTotal = table.Column<int>(type: "int", nullable: false),
                    NetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettlementDetails_SettlementCategories_SettlementCategoryId",
                        column: x => x.SettlementCategoryId,
                        principalTable: "SettlementCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SettlementDetails_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettlementDetails_SettlementCategoryId",
                table: "SettlementDetails",
                column: "SettlementCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementDetails_TransactionId",
                table: "SettlementDetails",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FinancialInstitutionId",
                table: "Transactions",
                column: "FinancialInstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettlementDetails");

            migrationBuilder.DropTable(
                name: "SettlementCategories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "FinancialInstitutions");
        }
    }
}
