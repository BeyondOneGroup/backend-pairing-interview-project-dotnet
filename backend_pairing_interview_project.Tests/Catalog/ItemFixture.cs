using backend_pairing_interview_project.catalog;
using backend_pairing_interview_project.utils;

namespace backend_pairing_interview_project.Tests.Catalog
{
    public static class ItemFixture
    {
        public static Item GetItemOne()
        {
            return new Item
            {
                Id = "item1",
                Name = "Bottle",
                Description = "Water bottle",
                Price = new Money(10.4m),
                Cost = new Money(10.4m)
            };
        }

        public static Item GetItemTwo()
        {
            return new Item
            {
                Id = "item2",
                Name = "Bubble",
                Description = "Mint flavoured bubble",
                Price = new Money(2.5m),
                Cost = new Money(1.0m)
            };
        }

        public static Item GetItemThree()
        {
            return new Item
            {
                Id = "item3",
                Name = "Chips",
                Description = "Crunchy chips",
                Price = new Money(1.5m),
                Cost = new Money(1.0m)
            };
        }

        public static ItemsManagementItemDto GetItemManagementItemDto()
        {
            return new ItemsManagementItemDto
            {
                Id = "itemId",
                Name = "itemName",
                Description = "itemDescription",
                Price = 1.3m,
                Cost = 0.5m
            };
        }
    }
}
