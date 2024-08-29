using eCommerceWebApiBackEnd.Data;
using eCommerceWebApiBackEnd.Services.CategoryService;
using eCommerceWebApiBackEnd.Services.ProductService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("eCommerceBlazorFrontEnd",
        builder => builder
            .WithOrigins("https://localhost:7041")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

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
// Enable CORS
app.UseCors("eCommerceBlazorFrontEnd");

app.UseAuthorization();

app.MapControllers();

app.Run();
