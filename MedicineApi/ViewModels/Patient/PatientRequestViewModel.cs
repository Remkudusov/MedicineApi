using MedicineApi.Configuration.Converters;
using MedicineApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MedicineApi.ViewModels.Hospital
{
    /// <summary>
    /// Представление входящей модели пациента (на добавление или редактирование).
    /// </summary>
    public class PatientRequestViewModel
    {
        /// <summary>
        /// Фамилия пациента.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать фамилию пациента.")]
        public string Surname { get; set; }

        /// <summary>
        /// Имя пациента.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать имя пациента.")]
        public string Name { get; set; }

        /// <summary>
        /// Отчество пациента.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать отчество пациента.")]
        public string Patronymic { get; set; }

        /// <summary>
        /// Адрес пациента.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать адрес пациента.")]
        public string Address { get; set; }

        /// <summary>
        /// Дата рождения пациента.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать дату рождения пациента.")]
        public DateOnly BDay { get; set; }

        /// <summary>
        /// Пол пациента.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать пол пациента.")]
        public Sex Sex { get; set; }

        /// <summary>
        /// Идентификатор участка пациента.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать идентификатор участка, к которому прикреплён пациент.")]
        [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора участка.")]
        public long DistrictId { get; set; }
    }
}
