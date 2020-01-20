namespace NetCoreApiVersioning.Dto.Widgets
{
    public class WidgetGetDtoV3
    {
        //In V3 WidgetName was changed to Name
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
