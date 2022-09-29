namespace RTLMaze.Core;

public static class EnumerationExtensions
{
	public static IEnumerable<T> ForEach<T>(  this IEnumerable<T> source, Action<T> action )
	{
		var sourceList = source.ToList();
		foreach ( var item in sourceList )
			action( item );

		return sourceList;
	}
}