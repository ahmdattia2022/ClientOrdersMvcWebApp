using ClientOrdersMvcWebApp.BL.Helper;
using ClientOrdersMvcWebApp.BL.Interface;
using ClientOrdersMvcWebApp.DAL;
using ClientOrdersMvcWebApp.DAL.Entities;
using ClientOrdersMvcWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.BL.Repository
{
    public class ClientRep : IClientRep
    {
        private readonly IClientRep client;
        private readonly ApplicationDbCobtext db;

        public ClientRep(IClientRep client, ApplicationDbCobtext db)
        {
            this.client = client;
            this.db = db;
        }
        public void Add(ClientVM client)
        {
            Client _client = new Client();
            _client.Id = client.Id;
            _client.Email = client.Email;
            _client.Active = client.Active;
            _client.FullName = client.FullName;
            _client.MobilePhone = client.MobilePhone;
            _client.Password = Password.hashPassword(client.Password);
            _client.Username = client.Username;

            db.Clients.Add(_client);
            db.SaveChanges();
        }

        public void Delete(int ID)
        {
            var oldClient = db.Clients.Find(ID);
            db.Clients.Remove(oldClient);
            db.SaveChanges();
        }

        public IQueryable<ClientVM> Get()
        {
            return db.Clients.Select(c => new ClientVM
                    { 
                        FullName = c.FullName,
                        Active = c.Active,
                        Email = c.Email,
                        Id = c.Id,
                        MobilePhone = c.MobilePhone,
                        Password = Convert.ToBase64String(c.Password),
                        Username = c.Username,
                        
                        
                    });
        }

        public ClientVM GetByID(int ID)
        {
            return db.Clients.Where(x => x.Id == ID).Select(c => new ClientVM
            {
                FullName = c.FullName,
                Active = c.Active,
                Email = c.Email,
                Id = c.Id,
                MobilePhone = c.MobilePhone,
                Password = Convert.ToBase64String(c.Password),
                Username = c.Username
            }).FirstOrDefault();
        }

        public void Update(ClientVM client)
        {

        }
    }
}
