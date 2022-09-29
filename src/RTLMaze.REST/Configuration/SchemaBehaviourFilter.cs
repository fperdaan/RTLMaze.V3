using System.Reflection;
using System.Text.Json;
using Microsoft.OpenApi.Any;
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
			.Select( prop => new
			{
				Meta = prop, 
				RefName = schema.Properties.Keys.SingleOrDefault( p => p.ToLower().Equals( prop.Name.ToLower() ) ),
				Behaviour = prop.GetCustomAttribute<SchemaBehaviour>()
			})
			.Where( prop => prop.Behaviour != null && prop.RefName != null )
			.ForEach( prop =>
			{
				// -- Filter props
				if ( prop.Behaviour!.Exclude == true )
				{
					schema.Properties.Remove( prop.RefName! );
				}
				
				//  -- Other actions
				// ....
			});
	}
}