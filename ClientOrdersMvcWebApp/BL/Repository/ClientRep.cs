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
        private readonly ApplicationDbCobtext db;

        public ClientRep(ApplicationDbCobtext db)
        {
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

        public ClientVM GetByEmail(LoginVM loginVM)
        {
            var pass = Password.hashPassword(loginVM.Password);

            var client = db.Clients.Where(x => x.Email == loginVM.Email && x.Password == pass).FirstOrDefault();
            ClientVM _client = new ClientVM();
            if (client != null)
            {
                _client.Id = client.Id;
                _client.Email = client.Email;
                _client.Active = client.Active;
                _client.FullName = client.FullName;
                _client.MobilePhone = client.MobilePhone;
                _client.Username = client.Username;
            }

            return _client;
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

        public ClientVM GetById(int ID)
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
