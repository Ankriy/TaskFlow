using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Logic.Domain.Models.Orders.Enums
{
    public class PaymentMethodHelper
    {
        public static int GetIdFromName(string name)
        {
            if (Enum.TryParse(name, out PaymentMethodType method))
            {
                return (int)method;
            }
            else
            {
                // Handle the case where the name is invalid
                return -1; // Or throw an exception, etc.
            }
        }
    }
}
