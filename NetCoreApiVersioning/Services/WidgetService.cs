using CSharpFunctionalExtensions;
using NetCoreApiVersioning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiVersioning.Services
{
    public class WidgetService : IWidgetService
    {
        private List<Widget> _widgets = new List<Widget>()
            {
                new Widget("Widget One", 1,  29.99m),
                new Widget("Widget Two", 2, 9.99m),
                new Widget("Widget Three", 3, 2.97m),
                new Widget("Widget Four", 4, .98m)
            };

        public IEnumerable<Widget> Get()
        {
            return _widgets;
        }

        public Widget Get(int id)
        {
            return _widgets.FirstOrDefault(i => i.Id == id);
        }

        public Result<Widget> Add(string widgetName, decimal price)
        {
            var id = _widgets.Max(i => i.Id) + 1;
            var widget = new Widget(widgetName, id, price);
            _widgets.Add(widget);
            return Result.Ok(widget);
        }
    }
}
