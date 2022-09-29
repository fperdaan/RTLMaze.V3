using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RTLMaze.Core.Serializers;
using RTLMaze.REST.Configuration;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

var mvcBuilder = builder.Services.AddControllers();

mvcBuilder.AddJsonOptions( opt =>
{
	opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
	opt.JsonSerializerOptions.Converters.Add( new DateOnlyNullableSerializer() );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
	c.SchemaFilter<SchemaBehaviourFilter>();
	c.SchemaFilter<SchemaNameFilter>();

	//c.CustomSchemaIds( modelType => { });
	
	c.MapType<DateOnly>(() => new OpenApiSchema { 
		Type = "string",
		Pattern = DateOnlyNullableSerializer.DATE_FORMAT,
		Example = new OpenApiString( DateOnly.FromDateTime( DateTime.Now ).ToString( DateOnlyNullableSerializer.DATE_FORMAT ) )
	});
});

builder.Services.AddRouting( opt => opt.LowercaseUrls = true );

builder.Services.AddControllers( options => 
{
 	options.Filters.Add<ResponseActionHandler>();
});

// Register our mapping service
builder.Services.AddAutoMapper( typeof( Program ) );

var app = builder.Build();

// Configure the HTTP request pipeline.
//if ( app.Environment.IsDevelopment() )
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();