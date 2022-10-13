using MedicineApi.Configuration.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace MedicineApi.Extensions
{
    /// <summary>
    /// Методы расширения для типов преобразований данных в хранимые.
    /// </summary>
    public static class ValueConversionExtensions
    {
        /// <summary>
        /// Конфигурирует преобразование перечисления в строку.
        /// </summary>
        /// <typeparam name="T">Тип перечисления.</typeparam>
        /// <param name="propertyBuilder"></param>
        /// <returns></returns>
        public static PropertyBuilder<T> HasEnumConversion<T>(this PropertyBuilder<T> propertyBuilder)
            where T : struct, Enum
        {
            var converter = new ValueConverter<T, string>(
                x => x.ToString(),
                x => Enum.Parse<T>(x));

            propertyBuilder.HasConversion(converter);
            propertyBuilder.Metadata.SetValueConverter(converter);

            return propertyBuilder;
        }
    }
}
