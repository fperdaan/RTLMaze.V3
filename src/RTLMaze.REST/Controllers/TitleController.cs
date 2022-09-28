using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RTLMaze.Core.Serializers;
using RTLMaze.Models;

namespace RTLMaze.REST.Controllers;

[ApiController]
[Route("[controller]")]
public class TitleController : ControllerBase
{
	[HttpGet, Route("")]
	public void List()
	{
		
	}
	
	[HttpGet, Route("{id:int}")]
	public Title Get( int id )
	{
		var title = new Title { Id = 1, Name = "Under the Dome", Premiered = DateOnly.Parse("2013-06-24") };
		
		return title;
	}
}