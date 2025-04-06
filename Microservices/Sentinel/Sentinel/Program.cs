using SentinelAbstraction.Settings;
using SentinelBusinessLayer.Injections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRefitClients(builder.Configuration);
builder.Services.AddSentinelServices();

builder.Services.Configure<TreatmentClientSettings>(builder.Configuration.GetSection("RefitClients").GetSection(TreatmentClientSettings.SectionName));

builder.Services.AddControllers();
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
