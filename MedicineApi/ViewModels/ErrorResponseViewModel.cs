namespace MedicineApi.ViewModels
{
    /// <summary>
    /// Модель представления сообщения об ошибке.
    /// </summary>
    public class ErrorResponseViewModel
    {
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Инициализирует новую модель <see cref="ErrorResponseViewModel"/>
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public ErrorResponseViewModel(string message)
        {
            Message = message;
        }
    }
}
