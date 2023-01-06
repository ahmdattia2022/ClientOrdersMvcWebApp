using ClientOrdersMvcWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.BL.Interface
{
    public interface IClientRep
    {
        IQueryable<ClientVM> Get();
        ClientVM GetByID(int ID);
        void Add(ClientVM client);
        void Update(ClientVM client);
        void Delete(int ID);
    }
}
