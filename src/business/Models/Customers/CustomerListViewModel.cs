

using business.Logic.Domain.Models.Customer;

namespace business.Application.Web.Models.Customers
{
    public class CustomerListViewModel
    {
        public List<CustomerShortViewModel> Users { get; set; }

        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }

        public CustomerListViewModel()
        {
            Users = new List<CustomerShortViewModel>();
        }

        public CustomerListViewModel(Customer list, int page, int size)
        {
            //Users = new List<CustomerShortViewModel>();
            //foreach (Customer task in list.Users)
            //{
            //    Users.Add(new CustomerShortViewModel(task));
            //}

            //TotalCount = list.TotalCount;
            //Page = page;
            //PageSize = size;

            //CanBack = Page > 0;
            //CanForward = (Page + 1) * PageSize < TotalCount;
            //CanBack = Page > 0;
        }
    }
}
