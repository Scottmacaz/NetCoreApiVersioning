using AutoMapper;
using NetCoreApiVersioning.Dto.Widgets;

namespace NetCoreApiVersioning.Domain
{
    /// <summary>
    /// Any class that inherits from profile will be seen by automapper and the mappings will be loaded at startup.
    /// </summary>
    public class WidgetAutoMapperProfile : Profile
    {
        public WidgetAutoMapperProfile()
        {
            CreateMap<Widget, WidgetGetDto>().ForMember(dest => dest.WidgetName, opt => opt.MapFrom(src => src.Name));
            CreateMap<Widget, WidgetGetDtoV3>();
        }
    }
}
