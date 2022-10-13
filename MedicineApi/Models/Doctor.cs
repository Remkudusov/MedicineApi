using System.ComponentModel.DataAnnotations;

namespace MedicineApi.Models
{
    /// <summary>
    /// Модель доктора.
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// Идентификатор доктора.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ФИО доктора.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Идентификатор кабинета доктора.
        /// </summary>
        public long CabinetId { get; set; }

        /// <summary>
        /// Сущность кабинета доктора.
        /// </summary>
        public virtual Cabinet Cabinet { get; set; }

        /// <summary>
        /// Идентификатор специализации доктора.
        /// </summary>
        public long SpecializationId { get; set; }

        /// <summary>
        /// Сущность специализации доктора.
        /// </summary>
        public virtual Specialization Specialization { get; set; }

        /// <summary>
        /// Идентификатор участка доктора.
        /// </summary>
        public long? DistrictId { get; set; } = null;

        /// <summary>
        /// Сущность участка доктора.
        /// </summary>
        public virtual District? District { get; set; }
    }
}
