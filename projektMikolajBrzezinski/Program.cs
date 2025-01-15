using projektMikolajBrzezinski.IServices;
using projektMikolajBrzezinski.Services;
using projektMikolajBrzezinski.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<INBPService,NBPService>();
builder.Services.AddSingleton<IJsonDeserializer, JsonDeserializer>();
builder.Services.AddSingleton<ICsvExport, CsvExport>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
