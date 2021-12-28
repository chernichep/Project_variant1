﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Data;

namespace Project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211223160738_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Project.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("AggrementId")
                        .HasColumnType("int");

                    b.Property<int>("Aggrement_Id")
                        .HasColumnType("int");

                    b.Property<int?>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("Bank_Id")
                        .HasColumnType("int");

                    b.Property<int>("Type_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("AggrementId");

                    b.HasIndex("BankId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Project.Model.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("Project.Model.Aggrement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataClose")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpen")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aggrements");
                });

            modelBuilder.Entity("Project.Model.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AccounNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Project.Model.Account", b =>
                {
                    b.HasOne("Project.Model.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId");

                    b.HasOne("Project.Model.Aggrement", "Aggrement")
                        .WithMany("Accounts")
                        .HasForeignKey("AggrementId");

                    b.HasOne("Project.Model.Bank", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("BankId");

                    b.Navigation("AccountType");

                    b.Navigation("Aggrement");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Project.Model.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Project.Model.Aggrement", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Project.Model.Bank", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
