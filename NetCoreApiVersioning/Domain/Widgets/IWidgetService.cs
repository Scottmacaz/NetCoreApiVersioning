using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace NetCoreApiVersioning.Domain
{
    public interface IWidgetService
    {
        IEnumerable<Widget> Get();
        Widget Get(int id);
        Result<Widget> Add(string widgetName, decimal price);
    }
}