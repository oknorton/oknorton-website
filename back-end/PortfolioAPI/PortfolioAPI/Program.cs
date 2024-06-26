using Microsoft.EntityFrameworkCore;
using PortfolioAPI;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container
builder.Services.AddHttpClient<GithubService>(); 
builder.Services.AddScoped<GithubService>();
builder.Services.AddCors();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext for the application
// builder.Services.AddDbContext<PortfolioDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioDatabase")));
builder.Services.AddSingleton<PortfolioDbContext>(s=> new PortfolioDbContext(builder.Configuration));  

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     try
//     {
//         var context = services.GetRequiredService<PortfolioDbContext>();
//         DBSeeder.Initialize(context);
//     }
//     catch (Exception ex)
//     {
//         var logger = services.GetRequiredService<ILogger<Program>>();
//         logger.LogError(ex, "An error occurred while seeding the database.");
//     }
// }

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();