namespace business.Logic.Domain.Models.Orders.Enums
{
    public class OrderStatusHelper
    {
        public static int GetIdFromName(string name)
        {
            if (Enum.TryParse(name, out OrderStatusType method))
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
