﻿// <auto-generated />
using System;
using DataApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataApi.Migrations
{
    [DbContext(typeof(DataApiContext))]
    [Migration("20240611160546_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PublicPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("Models.Car", b =>
                {
                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FabricationYear")
                        .HasColumnType("int");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.HasKey("CarPlate");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Models.CarJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarPlate");

                    b.HasIndex("JobId");

                    b.ToTable("CarJob");
                });

            modelBuilder.Entity("Models.Cnh", b =>
                {
                    b.Property<long>("CnhNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CnhNumber"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("DadName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CnhNumber");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cnh");
                });

            modelBuilder.Entity("Models.CnhCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CnhCategory");
                });

            modelBuilder.Entity("Models.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardHolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CreditCard");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AdressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PDFDocument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CPF");

                    b.HasIndex("AdressId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Models.Dependent", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AdressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CPF");

                    b.HasIndex("AdressId");

                    b.ToTable("Dependent");
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AdressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CPF");

                    b.HasIndex("AdressId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AdressId")
                        .HasColumnType("int");

                    b.Property<decimal>("Comission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ComissionValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("CPF");

                    b.HasIndex("AdressId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Models.FinancialPending", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BillingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PendingDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerCPF");

                    b.ToTable("FinancialPending");
                });

            modelBuilder.Entity("Models.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DriverCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Franchise")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarPlate");

                    b.HasIndex("CustomerCPF");

                    b.HasIndex("DriverCPF");

                    b.ToTable("Insurance");
                });

            modelBuilder.Entity("Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreditCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PixId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardId");

                    b.HasIndex("PixId");

                    b.HasIndex("TicketId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Models.Pix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PixKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PixTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PixTypeId");

                    b.ToTable("Pix");
                });

            modelBuilder.Entity("Models.PixType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PixType");
                });

            modelBuilder.Entity("Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarPlate");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeCPF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SaleValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarPlate");

                    b.HasIndex("ClientCPF");

                    b.HasIndex("EmployeeCPF");

                    b.HasIndex("PaymentId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Models.CarJob", b =>
                {
                    b.HasOne("Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarPlate");

                    b.HasOne("Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Models.Cnh", b =>
                {
                    b.HasOne("Models.CnhCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.HasOne("Models.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Models.Dependent", b =>
                {
                    b.HasOne("Models.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.HasOne("Models.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.HasOne("Models.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.HasOne("Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Adress");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Models.FinancialPending", b =>
                {
                    b.HasOne("Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCPF");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Models.Insurance", b =>
                {
                    b.HasOne("Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarPlate");

                    b.HasOne("Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCPF");

                    b.HasOne("Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverCPF");

                    b.Navigation("Car");

                    b.Navigation("Customer");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Models.Payment", b =>
                {
                    b.HasOne("Models.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardId");

                    b.HasOne("Models.Pix", "Pix")
                        .WithMany()
                        .HasForeignKey("PixId");

                    b.HasOne("Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");

                    b.Navigation("CreditCard");

                    b.Navigation("Pix");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Models.Pix", b =>
                {
                    b.HasOne("Models.PixType", "PixType")
                        .WithMany()
                        .HasForeignKey("PixTypeId");

                    b.Navigation("PixType");
                });

            modelBuilder.Entity("Models.Purchase", b =>
                {
                    b.HasOne("Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarPlate");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Models.Sale", b =>
                {
                    b.HasOne("Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarPlate");

                    b.HasOne("Models.Customer", "Client")
                        .WithMany()
                        .HasForeignKey("ClientCPF");

                    b.HasOne("Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeCPF");

                    b.HasOne("Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
