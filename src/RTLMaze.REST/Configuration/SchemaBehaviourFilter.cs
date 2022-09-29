using System.Reflection;
using System.Text.Json;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using RTLMaze.Core;

namespace RTLMaze.REST.Configuration;

public class SchemaBehaviourFilter : ISchemaFilter
{
	public void Apply( OpenApiSchema schema, SchemaFilterContext context )
	{
		if ( schema?.Properties == null )
			return;

		context.Type.GetProperties()
			.Where( prop => prop.GetCustomAttribute<SchemaBehaviour>() is { Exclude: true } )
			.ForEach( prop =>
			{
				var foundProp = schema.Properties.Keys.SingleOrDefault( p => p.ToLower().Equals( prop.Name.ToLower() ) );

				if ( foundProp != null )
					schema.Properties.Remove( foundProp );
			});
	}
}