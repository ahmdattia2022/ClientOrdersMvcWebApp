using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Please Enter Order Serial No")]
        public string OrderSerialNo { get; set; }
        [Required(ErrorMessage = "Please Enter Order Date")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Please Enter Order Details")]
        public string OrderDetails { get; set; }
        [Required(ErrorMessage = "Please Enter Order Status")]
        public string OrderStatus { get; set; }
        public string Email { get; set; } //Stores client email
        public bool Active { get; set; }
    }
}
