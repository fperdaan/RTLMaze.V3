using System.Net;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Any;

namespace RTLMaze.REST;

public partial class ResponseWrapper<T> where T : class
{
	# region Props

	public int StatusCode { get; }
	private T? _data { get;  }

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public T? Data => IsError() ? null : _data;

	[SchemaBehaviour(Exclude=true)]
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public object? Errors => _data != null && IsError() ? CastErrorData( _data ) : null;
	
	# endregion
	
	# region Constructors
	
	public ResponseWrapper( int statusCode, T? data )
	{
		StatusCode = statusCode;
		_data = data;
	}

	public ResponseWrapper( HttpStatusCode statusCode, T? data ) : this( (int)statusCode, data ) {}

	# endregion
	
	# region State methods
	
	protected virtual bool IsError()
	{
		return StatusCode is >= 400 and < 600;
	}
	
	protected virtual object CastErrorData( object data )
	{
		return data switch
		{
			string => new [] { data },
			IEnumerable<string> => data,
			Exception item => new[] { item.Message },
			_ => data
		};
	}
	
	# endregion
}

public partial class ResponseWrapper : ResponseWrapper<object>
{
	public ResponseWrapper( int statusCode, object? data ) : base( statusCode, data ) { }

	public ResponseWrapper( HttpStatusCode statusCode, object? data ) : base( statusCode, data ) { }
}
