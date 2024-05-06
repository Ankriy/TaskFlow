using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace business.Logic.Domain.Models.Orders.Enums
{
    public enum OrderStatusType
    {
        Новый = 1,
        Вобработке = 2,
        Отправлен = 3,
        Доставлен = 4,
        Завершён = 5,
        Отменён = 6
    }
}
