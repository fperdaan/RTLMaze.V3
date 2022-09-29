namespace RTLMaze.Core;

public static class EnumerationExtensions
{
	public static void ForEach<T>(  this IEnumerable<T> source, Action<T> action )
	{
		foreach ( var item in source )
			action( item );
	}
}