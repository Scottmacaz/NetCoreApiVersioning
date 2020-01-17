using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiVersioning.Dto
{
    public class WidgetGetDto
    {
        public string WidgetName { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
