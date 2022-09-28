using RTLMaze.Core.Serializers;

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
builder.Services.AddSwaggerGen();

builder.Services.AddRouting( opt => opt.LowercaseUrls = true ); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();