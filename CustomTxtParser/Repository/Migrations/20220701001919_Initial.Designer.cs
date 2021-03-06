// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.DAL;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220701001919_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DomainModels.Models.Entities.FinancialInstitution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstitutionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FinancialInstitutions");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.SettlementCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SettlementCategories");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.SettlementDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountTotal")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FeeAmountCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FeeAmountDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ReconciliationAmntCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ReconciliationAmntDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SettlementCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionAmountCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TransactionAmountDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SettlementCategoryId");

                    b.HasIndex("TransactionId");

                    b.ToTable("SettlementDetails");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FXSettlementDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FinancialInstitutionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ReconciliationCurrency")
                        .HasColumnType("int");

                    b.Property<string>("ReconciliationFileID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionCurrency")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FinancialInstitutionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.SettlementDetail", b =>
                {
                    b.HasOne("DomainModels.Models.Entities.SettlementCategory", "SettlementCategory")
                        .WithMany("SettlementDetails")
                        .HasForeignKey("SettlementCategoryId");

                    b.HasOne("DomainModels.Models.Entities.Transaction", "Transaction")
                        .WithMany("SettlementDetails")
                        .HasForeignKey("TransactionId");

                    b.Navigation("SettlementCategory");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.Transaction", b =>
                {
                    b.HasOne("DomainModels.Models.Entities.FinancialInstitution", "FinancialInstitution")
                        .WithMany("Transactions")
                        .HasForeignKey("FinancialInstitutionId");

                    b.Navigation("FinancialInstitution");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.FinancialInstitution", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.SettlementCategory", b =>
                {
                    b.Navigation("SettlementDetails");
                });

            modelBuilder.Entity("DomainModels.Models.Entities.Transaction", b =>
                {
                    b.Navigation("SettlementDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
