using MedicineApi.Configuration.Converters;
using MedicineApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MedicineApi.ViewModels.Hospital
{
    /// <summary>
    /// Модель списочного представления пациента.
    /// </summary>
    public class PatientListViewModel
    {
        /// <summary>
        /// Идентификатор пациента.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Фамилия пациента.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя пациента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество пациента.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Адрес пациента.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Дата рождения пациента.
        /// </summary>
        public DateOnly BDay { get; set; }

        /// <summary>
        /// Пол пациента.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Номер участка.
        /// </summary>
        public long District { get; set; }
    }
}
