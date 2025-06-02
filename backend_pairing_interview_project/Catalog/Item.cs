using backend_pairing_interview_project.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_pairing_interview_project.catalog
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public Money Cost { get; set; }

        // Convert from ItemsManagementItemDto to Item
        public static Item From(ItemsManagementItemDto dto)
        {
            return new Item
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Price = new Money(dto.Price),
                Cost = new Money(dto.Cost)
            };
        }

        // Convert to ItemDto (public-facing DTO)
        public ItemDto ToItemDto()
        {
            return new ItemDto
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Price = this.Price.Value
            };
        }

        // Convert to ItemsManagementItemDto (admin-facing DTO)
        public ItemsManagementItemDto ToItemsManagementItemDto()
        {
            return new ItemsManagementItemDto
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                Price = this.Price.Value,
                Cost = this.Cost.Value
            };
        }
    }
}