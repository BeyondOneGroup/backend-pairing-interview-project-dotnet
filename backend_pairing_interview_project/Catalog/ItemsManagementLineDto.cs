using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_pairing_interview_project.catalog
{
    public class ItemsManagementLineDto
    {
        public int Quantity { get; set; }
        public ItemsManagementItemDto Item { get; set; }
    }
}