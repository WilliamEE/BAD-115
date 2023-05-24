using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class CategoryAwardsWithAwards
    {
        public CategoryAwards categoryAwardsPrivate { get; set; }

        public List<Organizations> organizationsPrivate { get; set; }
    }
}
