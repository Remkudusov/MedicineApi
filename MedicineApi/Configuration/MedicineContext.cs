using Microsoft.EntityFrameworkCore;
using MedicineApi.Configuration.Converters;
using MedicineApi.Models;
using MedicineApi.Extensions;

namespace MedicineApi.Configuration
{
    /// <summary>
    /// Контекст данных.
    /// </summary>
    public class MedicineContext : DbContext
    {
        /// <summary>
        /// Коллекция кабинетов.
        /// </summary>
        public DbSet<Cabinet> Cabinets { get; set; }

        /// <summary>
        /// Коллекция докторских специализаций.
        /// </summary>
        public DbSet<Specialization> Specializations { get; set; }

        /// <summary>
        /// Коллекция участков.
        /// </summary>
        public DbSet<District> Districts { get; set; }

        /// <summary>
        /// Коллекция докторов.
        /// </summary>
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// Коллекция пациентов.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Конструктор контекста.
        /// </summary>
        public MedicineContext(DbContextOptions<MedicineContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinet>().HasData(
                new List<Cabinet> {
                    new Cabinet { Id = 1, Number = 10 },
                    new Cabinet { Id = 2, Number = 17 },
                    new Cabinet { Id = 3, Number = 31 }
                });

            modelBuilder.Entity<Specialization>().HasData(
                new List<Specialization> {
                    new Specialization { Id = 1, Name = "Травматолог" },
                    new Specialization { Id = 2, Name = "Кардиолог" },
                    new Specialization { Id = 3, Name = "Физиотерапевт" },
                });

            modelBuilder.Entity<District>().HasData(
                new List<District> {
                    new District { Id = 1, Number = 4 },
                    new District { Id = 2, Number = 8 },
                    new District { Id = 3, Number = 9 }
                });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasOne(x => x.Cabinet)
                    .WithMany(x => x.Doctors)
                    .HasForeignKey(x => x.CabinetId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Specialization)
                    .WithMany(x => x.Doctors)
                    .HasForeignKey(x => x.SpecializationId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.District)
                    .WithMany(x => x.Doctors)
                    .HasForeignKey(x => x.DistrictId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(new List<Doctor>
                {
                    new Doctor
                    {
                        Id = 1,
                        FullName = "Иванов Иван Иванович",
                        CabinetId = 1,
                        SpecializationId = 1,
                        DistrictId = 1,
                    },
                    new Doctor
                    {
                        Id = 2,
                        FullName = "Петров Пётр Петрович",
                        CabinetId = 2,
                        SpecializationId = 2,
                    },
                    new Doctor
                    {
                        Id = 3,
                        FullName = "Семёнов Семён Семёнович",
                        CabinetId = 3,
                        SpecializationId = 3,
                        DistrictId = 3,
                    }
                });
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(x => x.Sex)
                    .HasEnumConversion();

                entity.HasOne(x => x.District)
                    .WithMany(x => x.Patients)
                    .HasForeignKey(x => x.DistrictId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasData(
                    new List<Patient>
                    {
                        new Patient
                        {
                            Id = 1,
                            Surname = "Иванов",
                            Name = "Игорь",
                            Patronymic = "Викторович",
                            Address = "Город Москва, улица Пушкина, дом 1, квартира 5",
                            BDay = new DateOnly(1987, 12, 1),
                            Sex = Sex.Male,
                            DistrictId = 3,
                        },
                        new Patient
                        {
                            Id = 2,
                            Surname = "Семёнов",
                            Name = "Иван",
                            Patronymic = "Александрович",
                            Address = "Город Санкт-Петербург, улица Ленина, дом 15, квартира 31",
                            BDay = new DateOnly(1961, 7, 25),
                            Sex = Sex.Male,
                            DistrictId = 1,
                        },
                        new Patient
                        {
                            Id = 3,
                            Surname = "Сидорова",
                            Name = "Виктория",
                            Patronymic = "Леонидовна",
                            Address = "Город Новосибирск, бульвар Свободы, дом 7Б, корпус 1, квартира 68",
                            BDay = new DateOnly(2001, 9, 30),
                            Sex = Sex.Female,
                            DistrictId = 2,
                        },
                    });

                entity.Property(x => x.BDay).HasConversion<DateOnlyConverter>();
            });
        }
    }
}
