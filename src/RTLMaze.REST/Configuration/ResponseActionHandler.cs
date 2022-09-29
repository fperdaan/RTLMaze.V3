using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RTLMaze.REST.Configuration;

public class ResponseActionHandler : IActionFilter, IOrderedFilter
{
	public int Order => int.MaxValue - 10;

	public void OnActionExecuting( ActionExecutingContext context ) 
	{ }

	public void OnActionExecuted( ActionExecutedContext context )
	{
		if ( context.Exception != null )
		{
			context.Result = new ObjectResult( context.Exception.Message ){ StatusCode = 500 };
			context.ExceptionHandled = true;
		}

		if ( context.Result is ObjectResult { Value: not ResponseWrapper } result ) 
			result.Value = new ResponseWrapper( result.StatusCode ?? 200, result.Value );
	}
}