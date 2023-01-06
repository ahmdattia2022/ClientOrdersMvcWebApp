using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250, MinimumLength =2)]
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
        public byte[] Password { get; set; }
        public bool Active { get; set; }
        
        [ForeignKey("ClientId")]
        public ICollection<Order> Orders { get; set; }
    }
}
