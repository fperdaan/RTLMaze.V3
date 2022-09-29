using Microsoft.OpenApi.Any;

namespace RTLMaze.REST;

[AttributeUsage(AttributeTargets.Property)]
public partial class SchemaBehaviour : Attribute
{
	public bool Exclude = false;
}