﻿// <auto-generated />
using System;
using DIPLOMA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DIPLOMA.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220409133457_AddFundraisingWidget")]
    partial class AddFundraisingWidget
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DIPLOMA.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NickName")
                        .IsUnique()
                        .HasFilter("[NickName] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DIPLOMA.Models.DonateMsg", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .IsRequired()
                        .HasColumnType("decimal(18, 4)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("DonateMsg");
                });

            modelBuilder.Entity("DIPLOMA.Models.FundraisingWidget", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BorderColorHex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(7)")
                        .HasDefaultValue("#000000");

                    b.Property<int>("BorderSize")
                        .HasColumnType("int");

                    b.Property<decimal?>("CollectedAmt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 4)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DigitsColorHex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(7)")
                        .HasDefaultValue("#000000");

                    b.Property<string>("HeaderText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("HideInitAndTargetAmounts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("IndicatorBackgroundColorHex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(7)")
                        .HasDefaultValue("#ffffff");

                    b.Property<string>("IndicatorColorHex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(7)")
                        .HasDefaultValue("#000000");

                    b.Property<decimal?>("InitialAmt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 4)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Radius")
                        .HasColumnType("int");

                    b.Property<decimal?>("TargetAmt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("FundraisingWidget");
                });

            modelBuilder.Entity("DIPLOMA.Models.MsgWidget", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayTimeSec")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(5);

                    b.Property<string>("HeaderText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MaxAmt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 4)")
                        .HasDefaultValue(1000m);

                    b.Property<int>("MaxSymbols")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(50);

                    b.Property<decimal?>("MinAmt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18, 4)")
                        .HasDefaultValue(10m);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("RandomContent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("ReadHeader")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("ReadMessage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("MsgWidget");
                });

            modelBuilder.Entity("DIPLOMA.Models.MsgWidgetContent", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AnimationFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MsgWidgetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SoundFileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AnimationFileId");

                    b.HasIndex("MsgWidgetID");

                    b.HasIndex("SoundFileId");

                    b.ToTable("MsgWidgetContent");
                });

            modelBuilder.Entity("DIPLOMA.Models.StatWidgetDirectionType", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CD")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StatWidgetDirectionType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CD = "RL",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3358),
                            Description = "Right -> Left",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3422),
                            Value = "left"
                        },
                        new
                        {
                            ID = 2,
                            CD = "LR",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3878),
                            Description = "Left -> Right",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3892),
                            Value = "right"
                        },
                        new
                        {
                            ID = 3,
                            CD = "TB",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3907),
                            Description = "Top -> Bottom",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3911),
                            Value = "down"
                        },
                        new
                        {
                            ID = 4,
                            CD = "BT",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3914),
                            Description = "Bottom -> Top",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3917),
                            Value = "up"
                        });
                });

            modelBuilder.Entity("DIPLOMA.Models.StatWidgetDisplayModeType", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CD")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("StatWidgetDisplayModeType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CD = "LL",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 410, DateTimeKind.Local).AddTicks(6806),
                            Description = "List",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 415, DateTimeKind.Local).AddTicks(9467)
                        },
                        new
                        {
                            ID = 2,
                            CD = "CL",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(512),
                            Description = "Сreeping line",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(535)
                        },
                        new
                        {
                            ID = 3,
                            CD = "SL",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(558),
                            Description = "Slider",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(561)
                        });
                });

            modelBuilder.Entity("DIPLOMA.Models.StatWidgetTimeIntervalType", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CD")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("StatWidgetTimeIntervalType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CD = "TD",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2059),
                            Description = "Today",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2123)
                        },
                        new
                        {
                            ID = 2,
                            CD = "AT",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2151),
                            Description = "All time",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2155)
                        },
                        new
                        {
                            ID = 3,
                            CD = "TW",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2158),
                            Description = "This week",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2161)
                        },
                        new
                        {
                            ID = 4,
                            CD = "7D",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2165),
                            Description = "Last 7 days",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2168)
                        },
                        new
                        {
                            ID = 5,
                            CD = "TM",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2171),
                            Description = "This month",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2174)
                        },
                        new
                        {
                            ID = 6,
                            CD = "30",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2177),
                            Description = "Last 30 Days",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2180)
                        },
                        new
                        {
                            ID = 7,
                            CD = "TY",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2183),
                            Description = "This Year",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2186)
                        },
                        new
                        {
                            ID = 8,
                            CD = "LY",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2190),
                            Description = "Last Year",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2193)
                        },
                        new
                        {
                            ID = 9,
                            CD = "24",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2196),
                            Description = "Last 24 hours",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2199)
                        });
                });

            modelBuilder.Entity("DIPLOMA.Models.StatWidgetType", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CD")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("StatWidgetType");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CD = "TP",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5010),
                            Description = "Top",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5073)
                        },
                        new
                        {
                            ID = 2,
                            CD = "LD",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5114),
                            Description = "Last Donater",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5127)
                        },
                        new
                        {
                            ID = 3,
                            CD = "CA",
                            CreatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5141),
                            Description = "Collected  amount",
                            UpdatedDate = new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5153)
                        });
                });

            modelBuilder.Entity("DIPLOMA.Models.StatisticWidget", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DirectionID")
                        .HasColumnType("int");

                    b.Property<int>("DisplayModeID")
                        .HasColumnType("int");

                    b.Property<int>("ElementsCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(5);

                    b.Property<string>("HeaderText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("ScrollingSpeed")
                        .HasColumnType("int");

                    b.Property<int>("TimeIntervalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WidgetTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DirectionID");

                    b.HasIndex("DisplayModeID");

                    b.HasIndex("TimeIntervalID");

                    b.HasIndex("UserID");

                    b.HasIndex("WidgetTypeID");

                    b.ToTable("StatisticWidget");
                });

            modelBuilder.Entity("DIPLOMA.Models.UploadFile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("UploadFile");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DIPLOMA.Models.DonateMsg", b =>
                {
                    b.HasOne("DIPLOMA.Models.ApplicationUser", "User")
                        .WithMany("DonateMsgs")
                        .HasForeignKey("UserID")
                        .HasConstraintName("FK__DonateMsg_UserID")
                        .IsRequired();
                });

            modelBuilder.Entity("DIPLOMA.Models.FundraisingWidget", b =>
                {
                    b.HasOne("DIPLOMA.Models.ApplicationUser", "User")
                        .WithMany("FundraisingWidgets")
                        .HasForeignKey("UserID")
                        .IsRequired();
                });

            modelBuilder.Entity("DIPLOMA.Models.MsgWidget", b =>
                {
                    b.HasOne("DIPLOMA.Models.ApplicationUser", "User")
                        .WithMany("MsgWidgets")
                        .HasForeignKey("UserID")
                        .HasConstraintName("FK__MsgWidget_UserID")
                        .IsRequired();
                });

            modelBuilder.Entity("DIPLOMA.Models.MsgWidgetContent", b =>
                {
                    b.HasOne("DIPLOMA.Models.UploadFile", "Animation")
                        .WithMany("MsgWidgetContentAnimation")
                        .HasForeignKey("AnimationFileId");

                    b.HasOne("DIPLOMA.Models.MsgWidget", "MsgWidget")
                        .WithMany("MsgWidgetContent")
                        .HasForeignKey("MsgWidgetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DIPLOMA.Models.UploadFile", "Sound")
                        .WithMany("MsgWidgetContentSound")
                        .HasForeignKey("SoundFileId");
                });

            modelBuilder.Entity("DIPLOMA.Models.StatisticWidget", b =>
                {
                    b.HasOne("DIPLOMA.Models.StatWidgetDirectionType", "Direction")
                        .WithMany("StatisticWidgets")
                        .HasForeignKey("DirectionID")
                        .IsRequired();

                    b.HasOne("DIPLOMA.Models.StatWidgetDisplayModeType", "DisplayMode")
                        .WithMany("StatisticWidgets")
                        .HasForeignKey("DisplayModeID")
                        .IsRequired();

                    b.HasOne("DIPLOMA.Models.StatWidgetTimeIntervalType", "TimeInterval")
                        .WithMany("StatisticWidgets")
                        .HasForeignKey("TimeIntervalID")
                        .IsRequired();

                    b.HasOne("DIPLOMA.Models.ApplicationUser", "User")
                        .WithMany("StatisticWidgets")
                        .HasForeignKey("UserID")
                        .HasConstraintName("FK__StatisticWidget_UserID")
                        .IsRequired();

                    b.HasOne("DIPLOMA.Models.StatWidgetType", "WidgetType")
                        .WithMany("StatisticWidgets")
                        .HasForeignKey("WidgetTypeID")
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DIPLOMA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DIPLOMA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DIPLOMA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DIPLOMA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
