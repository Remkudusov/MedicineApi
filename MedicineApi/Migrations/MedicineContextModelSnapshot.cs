// <auto-generated />
using System;
using MedicineApi.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicineApi.Migrations
{
    [DbContext(typeof(MedicineContext))]
    partial class MedicineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MedicineApi.Models.Cabinet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Cabinets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Number = 10L
                        },
                        new
                        {
                            Id = 2L,
                            Number = 17L
                        },
                        new
                        {
                            Id = 3L,
                            Number = 31L
                        });
                });

            modelBuilder.Entity("MedicineApi.Models.District", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Number = 4L
                        },
                        new
                        {
                            Id = 2L,
                            Number = 8L
                        },
                        new
                        {
                            Id = 3L,
                            Number = 9L
                        });
                });

            modelBuilder.Entity("MedicineApi.Models.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CabinetId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SpecializationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CabinetId = 1L,
                            DistrictId = 1L,
                            FullName = "Иванов Иван Иванович",
                            SpecializationId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            CabinetId = 2L,
                            FullName = "Петров Пётр Петрович",
                            SpecializationId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            CabinetId = 3L,
                            DistrictId = 3L,
                            FullName = "Семёнов Семён Семёнович",
                            SpecializationId = 3L
                        });
                });

            modelBuilder.Entity("MedicineApi.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BDay")
                        .HasColumnType("datetime2");

                    b.Property<long>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Город Москва, улица Пушкина, дом 1, квартира 5",
                            BDay = new DateTime(1987, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DistrictId = 3L,
                            Name = "Игорь",
                            Patronymic = "Викторович",
                            Sex = "Male",
                            Surname = "Иванов"
                        },
                        new
                        {
                            Id = 2L,
                            Address = "Город Санкт-Петербург, улица Ленина, дом 15, квартира 31",
                            BDay = new DateTime(1961, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DistrictId = 1L,
                            Name = "Иван",
                            Patronymic = "Александрович",
                            Sex = "Male",
                            Surname = "Семёнов"
                        },
                        new
                        {
                            Id = 3L,
                            Address = "Город Новосибирск, бульвар Свободы, дом 7Б, корпус 1, квартира 68",
                            BDay = new DateTime(2001, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DistrictId = 2L,
                            Name = "Виктория",
                            Patronymic = "Леонидовна",
                            Sex = "Female",
                            Surname = "Сидорова"
                        });
                });

            modelBuilder.Entity("MedicineApi.Models.Specialization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Травматолог"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Кардиолог"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Физиотерапевт"
                        });
                });

            modelBuilder.Entity("MedicineApi.Models.Doctor", b =>
                {
                    b.HasOne("MedicineApi.Models.Cabinet", "Cabinet")
                        .WithMany("Doctors")
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicineApi.Models.District", "District")
                        .WithMany("Doctors")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedicineApi.Models.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("District");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("MedicineApi.Models.Patient", b =>
                {
                    b.HasOne("MedicineApi.Models.District", "District")
                        .WithMany("Patients")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("MedicineApi.Models.Cabinet", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("MedicineApi.Models.District", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("MedicineApi.Models.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
