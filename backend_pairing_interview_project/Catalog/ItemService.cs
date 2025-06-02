using System.Collections.Generic;
using System.Linq;

namespace backend_pairing_interview_project.catalog
{
    public class ItemsService
    {
        private readonly ItemStore _itemStore;
        private readonly ItemAvailabilityManager _availabilityManager;

        public ItemsService(ItemStore itemStore, ItemAvailabilityManager availabilityManager)
        {
            _itemStore = itemStore;
            _availabilityManager = availabilityManager;
        }

        public List<LineDto> GetAllAvailableItems()
        {
            var quantities = _availabilityManager.GetAvailableItemQuantities();

            return quantities
                .Select(GetLineDto)
                .Where(dto => dto != null)
                .ToList();
        }

        public List<ItemsManagementLineDto> GetAllItems()
        {
            var quantities = _availabilityManager.GetAllItemQuantities();

            return quantities
                .Select(GetItemsManagementLineDto)
                .Where(dto => dto != null)
                .ToList();
        }

        private LineDto GetLineDto(KeyValuePair<string, int> entry)
        {
            string itemId = entry.Key;
            int quantity = entry.Value;

            var item = GetItem(itemId);
            if (item == null)
            {
                return null;
            }

            return new LineDto
            {
                Quantity = quantity,
                Item = item.ToItemDto()
            };
        }

        private ItemsManagementLineDto GetItemsManagementLineDto(KeyValuePair<string, int> entry)
        {
            string itemId = entry.Key;
            int quantity = entry.Value;

            var item = GetItem(itemId);
            if (item == null)
            {
                return null;
            }

            return new ItemsManagementLineDto
            {
                Quantity = quantity,
                Item = item.ToItemsManagementItemDto()
            };
        }

        private Item GetItem(string itemId)
        {
            try
            {
                return _itemStore.Get(itemId);
            }
            catch (ItemNotFoundException)
            {
                return null;
            }
        }

        public void AddItem(ItemsManagementItemDto dto, int quantity)
        {
            var item = Item.From(dto);
            _itemStore.Add(item);
            _availabilityManager.SetItemQuantity(item.Id, quantity);
        }

        public void Delete(ItemIdsDto itemIdsDto)
        {
            foreach (var itemId in itemIdsDto.Ids)
            {
                _itemStore.Delete(itemId);
                _availabilityManager.Delete(itemId);
            }
        }
    }
}