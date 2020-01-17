using AutoMapper;
using NetCoreApiVersioning.Domain;
using NetCoreApiVersioning.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiVersioning.Domain
{
    /// <summary>
    /// Any class that inherits from profile will be seen by automapper and the mappings will be loaded at startup.
    /// </summary>
    public class WidgetAutoMapperProfile : Profile
    {
        public WidgetAutoMapperProfile()
        {
            CreateMap<Widget, WidgetGetDto>();
        }
    }
}
