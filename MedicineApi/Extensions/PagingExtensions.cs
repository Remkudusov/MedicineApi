using MedicineApi.Models;
using MedicineApi.ViewModels;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

namespace MedicineApi.Extensions
{
    /// <summary>
    /// Методы расширения для работы с постраничной навигацией.
    /// </summary>
    public static class PagingExtensions
    {
        /// <summary>
        /// Экранировать список врачей постранично и отсортировать по столбцу.
        /// </summary>
        /// <param name="doctors">Список докторов.</param>
        /// <param name="paging">Модель для постраничной навигации и сортировки.</param>
        /// <returns>Экранированный список врачей.</returns>
        public static IEnumerable<Doctor> Paginate(this IEnumerable<Doctor> doctors, PagingModel paging)
        {
            if (paging.SortColumn is not null)
                doctors = doctors.AsQueryable().OrderBy(paging.SortColumn + " " + paging.SortDirection);

            var offset = (paging.PageNumber - 1) * paging.PageSize;
            var result = doctors.Skip(offset).Take(paging.PageSize);

            return result;
        }

        /// <summary>
        /// Экранировать список пациентов постранично и отсортировать по столбцу.
        /// </summary>
        /// <param name="patients">Список пациентов.</param>
        /// <param name="paging">Модель для постраничной навигации и сортировки.</param>
        /// <returns>Экранированный список пациентов.</returns>
        public static IEnumerable<Patient> Paginate(this IEnumerable<Patient> patients, PagingModel paging)
        {
            if (paging.SortColumn is not null)
                patients = patients.AsQueryable().OrderBy(paging.SortColumn + " " + paging.SortColumn);

            var offset = (paging.PageNumber - 1) * paging.PageSize;
            var result = patients.Skip(offset).Take(paging.PageSize);

            return result;
        }
    }
}
