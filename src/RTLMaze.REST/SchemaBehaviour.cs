namespace RTLMaze.REST;

[AttributeUsage(AttributeTargets.Property)]
public class SchemaBehaviour : Attribute
{
	public bool Exclude = false;
}