using Tutorial11.Datas;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContentext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();