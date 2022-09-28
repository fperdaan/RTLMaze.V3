using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RTLMaze.Core.Serializers;
using RTLMaze.Models;
using RTLMaze.REST.Dto;

namespace RTLMaze.REST.Controllers;

[ApiController]
[Route("[controller]")]
public class TitleController : ControllerBase
{
	private readonly IMapper _mapper;

	public TitleController( IMapper mapper )
	{
		_mapper = mapper;
	}
	
	[HttpGet, Route("")]
	public void List()
	{
		
	}
	
	[HttpGet, Route("{id:int}")]
	public TitleDto Get( int id )
	{
		var title = new Title { Id = 1, Name = "Under the Dome", Premiered = DateOnly.Parse("2013-06-24") };
		
		return _mapper.Map<TitleDto>( title );
	}
}