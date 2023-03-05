using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
namespace Catalog.Repository
{

    public class OrderRePository : IOrderRePository
    {

        private readonly List<Order> orders = new() {
            new Order() {Id = new Random().Next(), OrderName = "Smart Phone", OrdePrice = 1000000, CreatedDate = DateTimeOffset.UtcNow},
            new Order() {Id =  new Random().Next(), OrderName = "Smart Watch", OrdePrice = 1000000, CreatedDate = DateTimeOffset.UtcNow},
            new Order() {Id =  new Random().Next(), OrderName = "Latop", OrdePrice = 1000000, CreatedDate = DateTimeOffset.UtcNow},
        };

        public IEnumerable<Order> GetOrders() => orders;


        public Order GetOrder(int id) => orders.Where(order => order.Id == id).SingleOrDefault();

        public void CreateOrder(Order order)
        {
            // var index = orders.FindIndex(existingOrder => existingOrder.Id == order.Id);
            // if (index != +1) { return; };
            orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            var index = orders.FindIndex(existingOrder => existingOrder.Id == order.Id);

            if (index != -1) orders[index] = order;
        }

        public void DeleteOrder(int id)
        {
            var index = orders.FindIndex(existing => existing.Id == id);
            if (index != -1)
            {
                orders.RemoveAt(index);
            }
        }
    }
}