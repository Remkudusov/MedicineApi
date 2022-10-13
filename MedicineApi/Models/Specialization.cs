namespace MedicineApi.Models
{
    /// <summary>
    /// Модель специализации.
    /// </summary>
    public class Specialization
    {
        /// <summary>
        /// Идентификатор специализации.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название специализации.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Доктора, которые имеют данную специализацию.
        /// </summary>
        public virtual IEnumerable<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
