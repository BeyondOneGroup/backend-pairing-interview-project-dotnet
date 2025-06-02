using System;
using System.Collections.Generic;
using System.Linq;

namespace backend_pairing_interview_project.catalog
{
    public class ItemAvailabilityManager
    {
        private const int MinItemQuantityThreshold = 5;
        private readonly Dictionary<string, int> _itemQuantities;

        public ItemAvailabilityManager(Dictionary<string, int> itemQuantities)
        {
            _itemQuantities = itemQuantities ?? new Dictionary<string, int>();
        }

        public IDictionary<string, int> GetAvailableItemQuantities()
        {
            return _itemQuantities
                .Where(entry => entry.Value > 0)
                .ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public IDictionary<string, int> GetAllItemQuantities()
        {
            return _itemQuantities;
        }

        public void SetItemQuantity(string itemId, int quantity)
        {
            _itemQuantities[itemId] = quantity;
        }

        public void Delete(string itemId)
        {
            _itemQuantities.Remove(itemId);
        }

        public void DecrementQuantity(string itemId)
        {
            if (!_itemQuantities.ContainsKey(itemId))
            {
                throw new ItemNotFoundException("Item with ID {0} not found in store", itemId);
            }

            int current = _itemQuantities[itemId];
            int updated = current - 1;

            _itemQuantities[itemId] = updated;

            if (updated < MinItemQuantityThreshold)
            {
                Console.WriteLine($"[WARNING] Item {itemId} is low on stock: {updated} remaining");
            }
        }
    }
}