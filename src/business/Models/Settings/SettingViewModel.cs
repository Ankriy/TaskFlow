using business.Application.Web.Data.Entities;
using business.Logic.Domain.Models.Customers;
using business.Logic.Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace business.Application.Web.Models.Settings
{
    public class SettingViewModel
    {
        public long Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Photo { get; set; }
        public SettingViewModel() { }

        public SettingViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Firstname = user.FirstName;
            Lastname = user.LastName;
            Middlename = user.MiddleName;
            Email = user.Email;
            Login = user.UserName;
            Password = user.PasswordHash;
            Photo = user.Photo;
        }
    }
}
