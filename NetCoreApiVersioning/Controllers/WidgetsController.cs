﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiVersioning.Domain;
using NetCoreApiVersioning.Dto;
using NetCoreApiVersioning.Dto.Widgets;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApiVersioning.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    //Multiple ApiVersion attributes can be present to indicate no changes to this controller between versions.
    //This will be most of our controllers from version to version so I don't think we need version directories
    //under the controllers directory.  In a real app both versions would be deprecated so that this file could go away.
    [ApiController]
    [ApiVersion("1", Deprecated = true)]
    [ApiVersion("2")]
    [Route("api/[controller]")]
    
    public class WidgetsController : ControllerBase
    {
        private IWidgetService _widgetService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widgetService"></param>
        /// <param name="mapper"></param>
        public WidgetsController(IWidgetService widgetService, IMapper mapper)
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
            return Ok(_mapper.Map<IEnumerable<Widget>, List<WidgetGetDto>>(_widgetService.Get()));
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
            return Ok(_mapper.Map<Widget, WidgetGetDto>(widget));
        }

        /// <summary>
        /// Creates a new widget
        /// </summary>
        /// <param name="widgetPostDto"></param>
        /// <returns></returns>
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




