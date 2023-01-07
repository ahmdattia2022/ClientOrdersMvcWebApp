using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.ViewModel
{
    public class LoginVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is requried!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is requried!")]
        public string Password { get; set; }
    }
}
