using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiVersioning.Domain;
using NetCoreApiVersioning.Dto;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApiVersioning.Controllers
{
    //Multiple ApiVersion attributes can be present to indicate no changes to this controller between versions.
    [ApiVersion("1")]
   // [ApiVersion("2")]
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetsController : ControllerBase
    {
        private IWidgetService _widgetService;
        private readonly IMapper _mapper;

        public WidgetsController(IWidgetService widgetService, IMapper mapper)
        {
            _widgetService = widgetService;
            _mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _mapper.Map<IEnumerable<Widget>, List<WidgetGetDto>>(_widgetService.Get()));
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(Get))]
        public ActionResult<Widget> Get(int id)
        {
            var widget = _widgetService.Get(id);
            if (widget == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Widget, WidgetGetDto>(widget));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] WidgetPostDto widgetPostDto)
        {
            var widgetOrError = _widgetService.Add(widgetPostDto.WidgetName, widgetPostDto.Price);
            if (widgetOrError.IsFailure)
            {
                return BadRequest(widgetOrError.Error);
            }
            var widgetDto = _mapper.Map<Widget, WidgetGetDto>(widgetOrError.Value);
            return CreatedAtRoute(nameof(Get), new { id = widgetOrError.Value.Id }, widgetDto);
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
