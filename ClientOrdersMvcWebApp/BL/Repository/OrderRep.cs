using ClientOrdersMvcWebApp.BL.Interface;
using ClientOrdersMvcWebApp.DAL;
using ClientOrdersMvcWebApp.DAL.Entities;
using ClientOrdersMvcWebApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOrdersMvcWebApp.BL.Repository
{
    public class OrderRep : IOrderRep
    {
        private readonly ApplicationDbCobtext db;

        public OrderRep(ApplicationDbCobtext db)
        {
            this.db = db;
        }
        public void Add(OrderVM order)//add new order
        {
            var _order = new Order();
            _order.Id = order.Id;
            _order.ClientId = order.ClientId;
            _order.OrderDate = order.OrderDate;
            _order.OrderDetails = order.OrderDetails;
            _order.OrderSerialNo = order.OrderSerialNo;
            _order.OrderStatus = order.OrderStatus;
            _order.Active = order.Active;

            db.Orders.Add(_order);
            db.SaveChanges();
        }

        public void Delete(int ID)//delete order from order list
        {
            var oldOrder = db.Orders.Find(ID);
            db.Orders.Remove(oldOrder);
            db.SaveChanges();
        }

        public IQueryable<OrderVM> Get(int clientId)//get all orders based on client id
        {
            return db.Orders.Where(x => x.ClientId == clientId).Select(x => new OrderVM { 
                Active = x.Active,
                ClientId = x.ClientId,
                Id = x.Id,
                OrderDate = x.OrderDate,
                OrderDetails = x.OrderDetails,
                OrderSerialNo = x.OrderSerialNo,
                OrderStatus = x.OrderStatus
            });
        }

        public OrderVM GetByID(int ID)//get order by order id
        {
            return db.Orders.Where(x => x.Id == ID).Select(x => new OrderVM
            {
                Active = x.Active,
                ClientId = x.ClientId,
                Id = x.Id,
                OrderDate = x.OrderDate,
                OrderDetails = x.OrderDetails,
                OrderSerialNo = x.OrderSerialNo,
                OrderStatus = x.OrderStatus
            }).FirstOrDefault();
        }

        public void Update(OrderVM order)//update existing order
        {
            var _order = db.Orders.Find(order.Id);

            _order.Id = order.Id;
            _order.ClientId = order.ClientId;
            _order.OrderDate = order.OrderDate;
            _order.OrderDetails = order.OrderDetails;
            _order.OrderSerialNo = order.OrderSerialNo;
            _order.OrderStatus = order.OrderStatus;
            _order.Active = order.Active;

            db.Entry(_order).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
