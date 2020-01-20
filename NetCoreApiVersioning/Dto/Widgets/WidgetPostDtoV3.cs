namespace NetCoreApiVersioning.Dto.Widgets
{
    public class WidgetPostDtoV3
    {
        //In V3 WidgetName was changed to Name.
        //Note in a real app automapper would most likely be used to not break the API.
        //In other words, the domain would change to "Name" but the API would retain, and map,
        //the Name to WidgetName so the API wouldn't break.
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
