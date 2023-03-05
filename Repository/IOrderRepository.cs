
using System;
using Catalog.Entities;
using System.Collections.Generic;

namespace Catalog.Repositories
{
    public interface IOrderRePository
    {
        void CreateOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();
        void UpdateOrder(Order order);
    }
}