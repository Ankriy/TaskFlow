using System.ComponentModel.DataAnnotations;

namespace business.Logic.Domain.Models.Orders.Enums
{
    public enum PaymentMethodType
    {
        Наличные = 1,
        Карта = 2,
        Перевод = 3,
        [Display(Name = "Не указано")]
        Неуказано = 4
    }
}
