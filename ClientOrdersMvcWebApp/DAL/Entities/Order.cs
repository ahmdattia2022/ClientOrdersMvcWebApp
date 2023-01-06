using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string OrderSerialNo { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string OrderDetails { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        public bool Active { get; set; }

    }
}
