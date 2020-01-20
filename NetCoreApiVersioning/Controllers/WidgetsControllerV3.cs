using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiVersioning.Domain;
using NetCoreApiVersioning.Dto.Widgets;
using System.Collections.Generic;

namespace NetCoreApiVersioning.Controllers.V3
{
    /// <summary>
    /// 
    /// </summary>
    //Updates for v3:
    // * WidgetName has been updated to Name
    [ApiController]
    [ApiVersion("3")]
    [Route("api/[controller]")]

    public class WidgetsControllerV3 : ControllerBase
    {
        private IWidgetService _widgetService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widgetService"></param>
        /// <param name="mapper"></param>
        public WidgetsControllerV3(IWidgetService widgetService, IMapper mapper)
        {
            _widgetService = widgetService;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets all widgets blah blah blah 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<Widget>, List<WidgetGetDtoV3>>(_widgetService.Get()));
        }

        /// <summary>
        /// Gets a specific widget blah blah blah ...
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var widget = _widgetService.Get(id);
            if (widget == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Widget, WidgetGetDtoV3>(widget));
        }

        /// <summary>
        /// Creates a new widget
        /// </summary>
        /// <param name="widgetPostDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] WidgetPostDtoV3 widgetPostDto)
        {
            var widgetOrError = _widgetService.Add(widgetPostDto.Name, widgetPostDto.Price);
            if (widgetOrError.IsFailure)
            {
                return BadRequest(widgetOrError.Error);
            }
            var widgetDto = _mapper.Map<Widget, WidgetGetDtoV3>(widgetOrError.Value);
            return CreatedAtRoute(nameof(Get), new { id = widgetOrError.Value.Id }, widgetDto);

        }

        /// <summary>
        /// Replaces an existing widget
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Deletes a widget
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}




