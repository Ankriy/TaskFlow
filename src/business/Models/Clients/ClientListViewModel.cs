

//namespace business.Application.Web.Models.Clients
//{
//    public class ClientListViewModel
//    {
//        public List<ClientShortViewModel> Users { get; set; }

//        public int TotalCount { get; set; }
//        public int Page { get; set; }
//        public int PageSize { get; set; }

//        public bool CanBack { get; set; }
//        public bool CanForward { get; set; }

//        public ClientListViewModel()
//        {
//            Users = new List<ClientShortViewModel>();
//        }

//        public UserListViewModel(UserListDTO list, int page, int size)
//        {
//            Users = new List<UserShortViewModel>();
//            foreach (UserDTO task in list.Users)
//            {
//                Users.Add(new UserShortViewModel(task));
//            }

//            TotalCount = list.TotalCount;
//            Page = page;
//            PageSize = size;

//            CanBack = Page > 0;
//            CanForward = (Page + 1) * PageSize < TotalCount;
//            CanBack = Page > 0;
//        }
//    }
//}
