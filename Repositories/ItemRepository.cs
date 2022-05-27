using System;
using System.Collections.Generic;
using System.Linq;
using NodemassStore.Entities;
namespace NodemassStore.Repositories
{

    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Laptop", Price = 233, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Office Chair", Price = 200, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Office Table", Price = 100, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "AC", Price = 100, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            var response = items.Where(item => item.Id == id).SingleOrDefault();
            return response;
        }

        public Item CreateItem(Item item)
        {
            items.Add(item);
            return item;
        }

        public Item UpdateItem(Item item)
        {
            int itemIndex = items.FindIndex(i => i.Id == item.Id);
            if (itemIndex == -1) return null;
            items[itemIndex] = item;
            return item;
        }

        public bool DeleteItem(Guid id)
        {
            int itemIndex = items.FindIndex(i => i.Id == id);
            if (itemIndex == 1) return false;
            items.RemoveAt(itemIndex);
            return true;

        }
    }
}