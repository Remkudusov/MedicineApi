using System.ComponentModel.DataAnnotations;

namespace MedicineApi.ViewModels.Doctor
{
    /// <summary>
    /// Представление входящей модели доктора (на добавление или редактирование).
    /// </summary>
    public class DoctorRequestViewModel
    {
        /// <summary>
        /// ФИО.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать ФИО доктора.")]
        public string FullName { get; set; }

        /// <summary>
        /// Идентификатор кабинета.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать кабинет доктора.")]
        [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора кабинета.")]
        public long CabinetId { get; set; }

        /// <summary>
        /// Идентификатор специализации доктора.
        /// </summary>
        [Required(ErrorMessage = "Требуется указать специализацию доктора.")]
        [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора специализации.")]
        public long SpecializationId { get; set; }

        /// <summary>
        /// Идентификатор участка.
        /// </summary>
        [Range(1, long.MaxValue, ErrorMessage = "Неверное значение идентификатора участка.")]
        public long? DistrictId { get; set; } = null;
    }
}
