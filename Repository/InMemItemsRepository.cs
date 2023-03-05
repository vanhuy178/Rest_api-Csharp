using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
namespace Catalog.Repository
{

    public class InMemItemsRepository : IItemsRepository

    {
        private readonly List<Item> items = new()
        {
            new Item() {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item() {Id = Guid.NewGuid(), Name = "Iron Word", Price = 90, CreatedDate = DateTimeOffset.UtcNow},
            new Item() {Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 9, CreatedDate = DateTimeOffset.UtcNow}
        };

        // This method implements IEnumerable so that it can be used
        // with ForEach syntax.
        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            // to filter a sequence based on a predicate that involves the index of each element.
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}