namespace MedicineApi.ViewModels.Doctor
{
    /// <summary>
    /// Модель доктора (с ссылками).
    /// </summary>
    public class DoctorViewModel
    {
        /// <summary>
        /// Идентификатор доктора.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ФИО.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Идентификатор кабинета.
        /// </summary>
        public long CabinetId { get; set; }

        /// <summary>
        /// Идентификатор специализации доктора.
        /// </summary>
        public long SpecializationId { get; set; }

        /// <summary>
        /// Идентификатор участка.
        /// </summary>
        public long? DistrictId { get; set; } = null;
    }
}
