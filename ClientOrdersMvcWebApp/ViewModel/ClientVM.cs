using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.ViewModel
{
    public class ClientVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name is required!")]
        [StringLength(250, MinimumLength = 2)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Moblie Number is required!")]
        [Phone]
        public string MobilePhone { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        [Remote("IsEmailExist", "CLient", ErrorMessage = "Email address already exists")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(100, MinimumLength = 3)]
        [Remote("IsUserNameExist", "CLient", ErrorMessage = "Username already exists")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Repeat password is required")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string RepeatPassword { get; set; }
        public bool Active { get; set; }

    }
}
