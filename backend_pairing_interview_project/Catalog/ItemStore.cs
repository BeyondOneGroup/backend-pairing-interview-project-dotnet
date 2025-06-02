using System.Collections.Generic;
using System.Linq;

namespace backend_pairing_interview_project.catalog
{
    public class ItemStore
    {
        private readonly IDictionary<string, Item> _items;

        public ItemStore(IDictionary<string, Item> items)
        {
            _items = items ?? new Dictionary<string, Item>();
        }

        public Item Get(string id)
        {
            if (!_items.ContainsKey(id))
            {
                throw new ItemNotFoundException("Item with id: {0} not found in store", id);
            }

            return _items[id];
        }

        public List<Item> GetAllItems()
        {
            return _items.Values.ToList();
        }

        public void Add(Item item)
        {
            _items[item.Id] = item;
        }

        public void Delete(string itemId)
        {
            _items.Remove(itemId);
        }
    }
}