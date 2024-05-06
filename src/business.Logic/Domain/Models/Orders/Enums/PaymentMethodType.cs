using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
