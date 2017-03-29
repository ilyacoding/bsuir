using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Reference
    {
        public int GoodId { get; set; }
        public int CategoryId { get; set; }

        public Reference(int goodId, int categoryId)
        {
            GoodId = goodId;
            CategoryId = categoryId;
        }
    }
}
