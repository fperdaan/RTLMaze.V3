using AutoMapper;

namespace RTLMaze.REST.Extensions;

public static class QueryableExtension
{
	public static IQueryable<TOutput> MapDto<TOutput>( this IQueryable<object> source, IMapper mapper )
	{
		return source.Select( item => mapper.Map<TOutput>( item ) );
	}
}