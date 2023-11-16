using Api.Data.LocalRepositories;
using Api.Data.Repositories;
using Api.Datasource.SqlServerDataSource;
using Api.Repositories.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// inject connection string here
builder.Services.AddSingleton<ISqlClientFactory, SqlClientFactory>();

// inject repositories here
builder.Services.AddScoped<IInvoiceContract, InvoiceImplementLocal>();
builder.Services.AddScoped<IInvoiceDetailContract, InvoiceDetailImplementLocal>();
builder.Services.AddScoped<IProductContract, ProductImplementLocal>();
builder.Services.AddScoped<IClientContract, ClientImplementLocal>();
builder.Services.AddScoped<IClientTypeContract, ClientTypeImplementLocal>();


var app = builder.Build();

app.UseCors(options => {
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
