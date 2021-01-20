using System;
using System.Collections.Generic;
using Catalogue.Entities;

namespace Catalogue.Repositories
{
    public interface IItemsRepositories
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}