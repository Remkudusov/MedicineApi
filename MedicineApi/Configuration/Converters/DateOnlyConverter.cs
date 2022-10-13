using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicineApi.Configuration.Converters
{
    /// <summary>
    /// Конвертер из DateOnly в DateTime и наоборот.
    /// </summary>
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Конструктор конвертера.
        /// </summary>
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        {
        }
    }
}
