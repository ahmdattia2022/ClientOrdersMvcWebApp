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
    public class ClientController : Controller
    {
        private readonly ApplicationDbCobtext db;
        private readonly IClientRep client;

        public ClientController(IClientRep client, ApplicationDbCobtext db)
        {
            this.db = db;
            this.client = client;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(ClientVM _client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.Add(_client);
                    return RedirectToAction("Index", "Home");
                }

                return View(_client);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(_client);
            }

        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(ClientVM _client)
        {
            return View();
        }
    }
}
