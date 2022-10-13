namespace MedicineApi.ViewModels.Doctor
{
    /// <summary>
    /// Модель списочного представления доктора.
    /// </summary>
    public class DoctorListViewModel
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
        /// Номер кабинета.
        /// </summary>
        public long Cabinet { get; set; }

        /// <summary>
        /// Название специализации.
        /// </summary>
        public string Specialization { get; set; }

        /// <summary>
        /// Номер участка.
        /// </summary>
        public long? District { get; set; } = null;
    }
}
