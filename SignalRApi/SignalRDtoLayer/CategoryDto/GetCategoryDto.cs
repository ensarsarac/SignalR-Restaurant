using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.CategoryDto
{
    public class GetCategoryDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
