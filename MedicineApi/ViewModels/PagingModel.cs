using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace MedicineApi.ViewModels
{
    /// <summary>
    /// Модель постраничной навигации.
    /// </summary>
    public class PagingModel
    {
        /// <summary>
        /// Номер страницы (по-умолчанию отображается первая страница).
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Размер страницы (по-умолчанию отображается на одной странице 1000 элементов). Если -1 - то все.
        /// </summary>
        public int PageSize { get; set; } = 1000;

        /// <summary>
        /// Название поля, по которому выполняется сортировка.
        /// </summary>
        public string? SortColumn { get; set; }

        /// <summary>
        /// Тип сортировки, по-умолчанию - по убыванию. Сортировка выполняется, если указывается поле, по которому выполняется сортировка.
        /// </summary>
        public SortDirection SortDirection { get; set; } = SortDirection.DESC;
    }
}
