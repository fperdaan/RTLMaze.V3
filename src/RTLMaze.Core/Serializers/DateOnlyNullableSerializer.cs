using System.Text.Json;
using System.Text.Json.Serialization;

namespace RTLMaze.Core.Serializers;

public class DateOnlyNullableSerializer : JsonConverter<DateOnly?>
{
	private const string DATE_FORMAT = "yyyy-MM-dd";
	
	public override DateOnly? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
	{
		var value = reader.GetString();

		if ( value != null )
			return DateOnly.ParseExact( value, DATE_FORMAT );
		else
			return null;
	}

	public override void Write( Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options )
	{
		if( value != null )
			writer.WriteStringValue( ((DateOnly)value).ToString( DATE_FORMAT ) );
	}
}