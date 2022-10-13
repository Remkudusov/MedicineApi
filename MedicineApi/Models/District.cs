namespace MedicineApi.Models
{
    /// <summary>
    /// Модель участка.
    /// </summary>
    public class District
    {
        /// <summary>
        /// Идентификатор участка.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Номер участка.
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// Доктора, которые закреплены на данном участке.
        /// </summary>
        public virtual IEnumerable<Doctor> Doctors { get; set; } = new List<Doctor>();

        /// <summary>
        /// Пациенты, которые закреплены на данном участке.
        /// </summary>
        public virtual IEnumerable<Patient> Patients { get; set; } = new List<Patient>();
    }
}
