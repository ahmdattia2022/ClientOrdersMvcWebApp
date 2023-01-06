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
        [Required]
        [StringLength(250, MinimumLength = 2)]
        public string FullName { get; set; }
        [Required]
        [Phone]
        public string MobilePhone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public bool Active { get; set; }

    }
}
