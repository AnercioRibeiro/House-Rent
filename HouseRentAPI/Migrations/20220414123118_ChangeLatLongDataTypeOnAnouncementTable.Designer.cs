// <auto-generated />
using System;
using HouseRentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HouseRentAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220414123118_ChangeLatLongDataTypeOnAnouncementTable")]
    partial class ChangeLatLongDataTypeOnAnouncementTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HouseRentAPI.Models.Anouncement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Elevator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnergyType")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Floor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseTypology")
                        .HasColumnType("int");

                    b.Property<int>("Identifier")
                        .HasColumnType("int");

                    b.Property<DateTime>("InitialDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Parking")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<int>("SuiteNumber")
                        .HasColumnType("int");

                    b.Property<int>("Typology")
                        .HasColumnType("int");

                    b.Property<string>("WaterFount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Anouncements");
                });

            modelBuilder.Entity("HouseRentAPI.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("HouseRentAPI.Models.UserAnouncement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnouncementId")
                        .HasColumnType("int");

                    b.Property<int>("UserTenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnouncementId");

                    b.HasIndex("UserTenantId");

                    b.ToTable("UserAnouncements");
                });

            modelBuilder.Entity("HouseRentAPI.Models.UserTenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTenants");
                });

            modelBuilder.Entity("HouseRentAPI.Models.Anouncement", b =>
                {
                    b.HasOne("HouseRentAPI.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("HouseRentAPI.Models.UserAnouncement", b =>
                {
                    b.HasOne("HouseRentAPI.Models.Anouncement", "Anouncement")
                        .WithMany()
                        .HasForeignKey("AnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseRentAPI.Models.UserTenant", "UserTenant")
                        .WithMany()
                        .HasForeignKey("UserTenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anouncement");

                    b.Navigation("UserTenant");
                });
#pragma warning restore 612, 618
        }
    }
}
