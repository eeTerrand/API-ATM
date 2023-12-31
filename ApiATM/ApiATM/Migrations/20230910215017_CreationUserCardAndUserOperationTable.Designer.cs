﻿// <auto-generated />
using System;
using ApiATM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiATM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230910215017_CreationUserCardAndUserOperationTable")]
    partial class CreationUserCardAndUserOperationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiATM.Models.UserCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BankBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<int>("LoginAttempts")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserCards");
                });

            modelBuilder.Entity("ApiATM.Models.UserOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperationType")
                        .HasColumnType("int");

                    b.Property<int>("UserCardId")
                        .HasColumnType("int");

                    b.Property<decimal?>("WithdrawalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserCardId");

                    b.ToTable("UserOperation");
                });

            modelBuilder.Entity("ApiATM.Models.UserOperation", b =>
                {
                    b.HasOne("ApiATM.Models.UserCard", "UserCard")
                        .WithMany()
                        .HasForeignKey("UserCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCard");
                });
#pragma warning restore 612, 618
        }
    }
}
