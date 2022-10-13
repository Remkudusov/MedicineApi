using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MedicineApi.Extensions
{
    /// <summary>
    /// Методы расширения для SwaggerGen.
    /// </summary>
    public static class SwaggerGenOptionsExtensions
    {
        /// <summary>
        /// Маппинг из <see cref="DateOnly"/> в <see cref="string"/>.
        /// </summary>
        /// <param name="options">Опции конфигурации для Swagger.</param>
        public static void UseDateOnlyStringConverter(this SwaggerGenOptions options)
        {
            options.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
        }
    }
}
