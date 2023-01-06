using ClientOrdersMvcWebApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.DAL
{
    public class ApplicationDbCobtext:DbContext
    {
        public ApplicationDbCobtext(DbContextOptions<ApplicationDbCobtext> options):base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
