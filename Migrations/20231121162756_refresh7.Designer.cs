﻿// <auto-generated />
using AnkaraLab_BackEnd.WebAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnkaraLab_BackEnd.WebAPI.Migrations
{
    [DbContext(typeof(AnkaraLabDbContext))]
    [Migration("20231121162756_refresh7")]
    partial class refresh7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnkaraLab_BackEnd.WebAPI.Domain.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Baskets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 2,
                            OrderId = 2,
                            ProductId = 2,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("AnkaraLab_BackEnd.WebAPI.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Odbitka fotograficzna z procesu fotochemicznego",
                            Name = "Odbitka"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Wydruk atramentowy wysokiej jakości",
                            Name = "Wydruk wielkoformatowy"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Gadżety z plików cyfrowych",
                            Name = "Gadżety"
                        });
                });

            modelBuilder.Entity("AnkaraLab_BackEnd.WebAPI.Domain.Faq", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faqs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "dlab-2 (maszyna znajdująca się w posiadaniu AnkaraLab.com) naświetla zdjęcia z plików zapisanych w formatach .jpg, .tif, .bmp, .psd, których wielkość nie przekracza 100 Mb (przed kompresją).",
                            Question = "Jakie formaty plików są odczytywane prez laba?"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Tak, nie ma konieczności przerabiania plików, jeśli aparat zapisuje je w formacie obsługiwanym przez maszynę (patrz, pkt.1). Uwaga! Maszyna nie akceptuje plików RAW. Aby uzyskać najlepsze efekty zdjęcia można skadrować, znając dokładne formaty odbitek i ew. obrobić kolorystycznie, pamiętając o kalibracji monitora.",
                            Question = "Czy można wywołać zdjęcia z plików prosto z aparatu?"
                        });
                });

            modelBuilder.Entity("AnkaraLab_BackEnd.WebAPI.Domain.LoyaltyProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LoyaltyPrograms");
                });

            modelBuilder.Entity("AnkaraLab_BackEnd.WebAPI.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("InvoiceAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeliveryAddress = "Polna 10",
                            InvoiceAddress = "Rolnicza 12",
                            PaymentMethod = "Blik",
                            PaymentStatus = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            DeliveryAddress = "Stara 210",
                            InvoiceAddress = "Woronicza 121",
                            PaymentMethod = "PayU",
                            PaymentStatus = "Failed"
                        });
                });

            modelBuilder.Entity("AnkaraLab_BackEnd.WebAPI.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Deadline")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsAvaliable")
                        .HasColumnType("bit");

                    b.Property<int>("PhotoHeight")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<int>("PhotoWidth")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Deadline = 1,
                            Description = "Odbitka fotograficzna w formaciw 10x15",
                            IsAvaliable = true,
                            PhotoHeight = 102,
                            PhotoWidth = 152,
                            Price = 0.90000000000000002,
                            Size = "10x15"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Deadline = 1,
                            Description = "Odbitka fotograficzna w formacie 15x21",
                            IsAvaliable = true,
                            PhotoHeight = 152,
                            PhotoWidth = 210,
                            Price = 2.0,
                            Size = "15x21"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Deadline = 3,
                            Description = "Fotokula śnieżna",
                            IsAvaliable = true,
                            PhotoHeight = 100,
                            PhotoWidth = 100,
                            Price = 25.0,
                            Size = "10x10"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}