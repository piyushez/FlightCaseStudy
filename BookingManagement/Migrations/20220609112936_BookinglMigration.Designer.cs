// <auto-generated />
using System;
using BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingManagement.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20220609112936_BookinglMigration")]
    partial class BookinglMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingManagement.Models.FlightBookingTbl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiveIND")
                        .HasColumnType("bit");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightNumber")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoggedInUserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PnrNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FlightBookingTbl");
                });
#pragma warning restore 612, 618
        }
    }
}
