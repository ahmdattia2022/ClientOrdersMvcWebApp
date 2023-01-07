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
        private readonly IClientRep client;
        private readonly ApplicationDbCobtext db;
        ClientVM SignedInClient = new ClientVM();
        public ClientController(IClientRep _client, ApplicationDbCobtext db)
        {
            this.db = db;
            this.client = _client;
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
                    SignedInClient = _client;
                    return RedirectToAction("SingIn", "Client");
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
        public IActionResult SignIn(LoginVM _client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.GetByEmail(_client);
                    //filter home page based on the client (home page containing all products list
                    //and add to cart)
                    return RedirectToAction("Index", "Order", _client.Id);
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

        //validation for username exist
        public IActionResult IsUserNameExist(string username)
        {
            return Json(!db.Clients.Any(x => x.Username == username), new Newtonsoft.Json.JsonSerializerSettings());
        }
        //validaton for email exist
        public IActionResult IsEmailExist(string email)
        {
            return Json(!db.Clients.Any(x => x.Email == email), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
