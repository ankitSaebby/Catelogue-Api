using System;
using System.Collections.Generic;
using System.Linq;
using Catalogue.Entities;

namespace Catalogue.Repositories{

    public class InMemItemsRepositories : IItemsRepositories
    {
        private readonly List<Item> Items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Portion", Price = 9, createdDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Sword", Price = 20, createdDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Shield", Price = 17, createdDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return Items;
        }

        public Item GetItem(Guid id)
        {
            return Items.Where(Item => Item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            Items.Add(item);
        }

        public void upadateItem(Item item)
        {
            var itm=Items.FindIndex(exItem => exItem.Id == item.Id);
            Items[itm]=item;
        }
    }
}