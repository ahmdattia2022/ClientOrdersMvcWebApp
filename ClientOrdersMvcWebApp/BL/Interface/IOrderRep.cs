using ClientOrdersMvcWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.BL.Interface
{
    public interface IOrderRep
    {
        IQueryable<OrderVM> Get(int clientId);
        OrderVM GetByID(int ID);
        void Add(OrderVM dept);
        void Update(OrderVM dept);
        void Delete(int ID);
    }
}
