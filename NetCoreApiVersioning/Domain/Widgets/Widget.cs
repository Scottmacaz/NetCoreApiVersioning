using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiVersioning.Domain
{
    public class Widget
    {
        public string WidgetName { get; }
        public int Id { get; }
        public decimal Price { get; private set; }

        public Widget(string widgetName, int id, decimal price)
        {
            WidgetName = widgetName;
            Id = id;
            Price = price;
        }

        public Result IncreasePrice(decimal amount)
        {
            if (amount > 2)
            {
                return Result.Failure("A widgets price cannot increase by more than $2.");
            }
            Price += amount;
            return Result.Ok();
        }
        
    }
}
