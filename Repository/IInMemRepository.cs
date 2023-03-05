using System;
using Catalog.Entities;
using System.Collections.Generic;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item);

        void UpdatedItem(Item item);

        void DeleteItem(Guid id);
    }

}