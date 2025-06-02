using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_pairing_interview_project.catalog
{
    public class LineDto
    {
        public int Quantity { get; set; }
        public ItemDto Item { get; set; }
    }
}