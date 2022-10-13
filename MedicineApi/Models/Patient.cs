using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MedicineApi.Models
{
    /// <summary>
    /// Модель пациента.
    /// </summary>
    public class Patient
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
        [JsonConverter(typeof(StringEnumConverter))]
        public Sex Sex { get; set; }

        /// <summary>
        /// Идентификатор участка пациента.
        /// </summary>
        public long DistrictId { get; set; }

        /// <summary>
        /// Сущность участка пациента.
        /// </summary>
        public virtual District District { get; set; }
    }
}
