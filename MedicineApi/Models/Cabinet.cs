namespace MedicineApi.Models
{
    /// <summary>
    /// Модель кабинета.
    /// </summary>
    public class Cabinet
    {
        /// <summary>
        /// Идентификатор кабинета.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Номер кабинета.
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// Доктора, которые работают в данном кабинете.
        /// </summary>
        public virtual IEnumerable<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
