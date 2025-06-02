using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_pairing_interview_project.catalog
{
    public class ItemsManagementItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}