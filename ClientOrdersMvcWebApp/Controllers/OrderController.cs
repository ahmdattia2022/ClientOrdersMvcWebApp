using ClientOrdersMvcWebApp.BL.Interface;
using ClientOrdersMvcWebApp.DAL;
using ClientOrdersMvcWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRep order;
        private readonly IClientRep client;
        private readonly ApplicationDbCobtext db;
        public ClientVM CurrentClient = new ClientVM();

        public OrderController(IOrderRep _order,IClientRep _client, ApplicationDbCobtext db)
        {
            order = _order;
            client = _client;
            this.db = db;
        }
        //get all 
        public IActionResult Index(int clientId)//get orders list add by the signed in client
        {
            //check if user is logged in

            var data = order.Get(clientId);
            CurrentClient = client.GetById(clientId);
            return View(data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(OrderVM orderVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orderVM.ClientId = CurrentClient.Id;
                    order.Add(orderVM);
                    return RedirectToAction("Index", "Order");
                }

                return View(orderVM);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(orderVM);
            }
        }
    }
}
