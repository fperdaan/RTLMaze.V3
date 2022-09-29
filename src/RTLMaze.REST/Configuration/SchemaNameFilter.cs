using System.Text.RegularExpressions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RTLMaze.REST.Configuration;

public partial class SchemaNameFilter : ISchemaFilter
{

	public void Apply( OpenApiSchema schema, SchemaFilterContext context )
		=> schema.Title = GenerateName( context.Type );

	protected virtual string GenerateName( Type modelType )
	{
		// Create base name
		var name = ConcatenateDefaultName( modelType )
						.Replace("Dto", "");

		// Apply regex replacements
		name = Regex.Replace( name, @"I?(Async)?Enumerable", "[]" );
		name = Regex.Replace( name, @"^(.*?)Response[A-Z]*Wrapper$", "Response - $1", RegexOptions.IgnoreCase );
		
		return name;
	}

	protected virtual string ConcatenateDefaultName( Type modelType )
	{
		if ( !modelType.IsConstructedGenericType )
			return modelType.Name;
	
		var prefix = modelType.GetGenericArguments()
			.Select( ConcatenateDefaultName )
			.Aggregate( ( previous, current ) => previous + current);
	
		return prefix + modelType.Name.Split('`').First();
	}
}