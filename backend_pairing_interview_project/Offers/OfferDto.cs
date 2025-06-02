using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_pairing_interview_project.offers
{
    public class OfferDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemId { get; set; }
        public decimal PriceReduction { get; set; }
        public int? QuantityThreshold { get; set; }
    }
}