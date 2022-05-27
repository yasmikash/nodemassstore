using System;
using System.Collections.Generic;
using NodemassStore.Entities;

namespace NodemassStore.Repositories
{

    public interface IItemRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        Item CreateItem(Item item);
        Item UpdateItem(Item item);
        bool DeleteItem(Guid id);
    }
}