using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTLMaze.DAL;
using RTLMaze.Models;
using RTLMaze.REST.Dto;
using RTLMaze.REST.Extensions;

namespace RTLMaze.REST.Controllers;

[ApiController]
[Route("[controller]")]
public class TitleController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly IRepository<Title> _repository;

	public TitleController( IMapper mapper )
	{
		_mapper = mapper;
		//_repository = repository;
	}
	
	[HttpGet, Route("")]
	[Produces(typeof(IAsyncEnumerable<TitleDto>))]
	public IActionResult List()
	{
		var items = _repository
						.Query()
						.MapDto<TitleDto>( _mapper )
						.AsAsyncEnumerable();

		return Ok( items );
	}
	
	[HttpGet, Route("{id:int}")]
	[Produces(typeof(ResponseWrapper<TitleDto>))]
	public IActionResult Get( int id )
	{
//		var title = _repository.Get( id );

		Title? title = new Title { Id = 1, Name = "Under the Dome", Premiered = DateOnly.Parse("2013-06-24") };

		if ( title == null )
			return NotFound( "Unable to find the title with the specified id" );
		
		return Ok( _mapper.Map<TitleDto>( title ) );
	}
}