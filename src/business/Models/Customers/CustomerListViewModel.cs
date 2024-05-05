

using business.Logic.Domain.Models.Customers;

namespace business.Application.Web.Models.Customers
{
    public class CustomerListViewModel
    {
        public List<CustomerShortViewModel> Customers { get; set; }

        public EditCustomerViewModel CustomerForEdit { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }

        public CustomerListViewModel()
        {
            Customers = new List<CustomerShortViewModel>();
        }

        public CustomerListViewModel(CustomerList list, int page, int size)
        {
            Customers = new List<CustomerShortViewModel>();
            foreach (Customer customer in list.Customers)
            {
                Customers.Add(new CustomerShortViewModel(customer));
            }

            TotalCount = list.TotalCount;
            Page = page;
            PageSize = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * PageSize < TotalCount;
            CanBack = Page > 0;
        }
    }
}
