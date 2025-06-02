using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_pairing_interview_project.catalog
{
    public class ItemIdsDto
    {
        public List<string> Ids { get; set; }

        public IEnumerator<string> GetEnumerator() => Ids.GetEnumerator();
    }
}