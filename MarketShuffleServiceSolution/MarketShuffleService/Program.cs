using MarketShuffleService.Data_Access;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = "Server=localhost;Database=market_shuffle;Uid=root;Pwd=Cheeba969621!;";
        builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(
            connectionString
            ));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:5173") 
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        builder.Services.AddScoped<IItemRepository, ItemRepository>();
        builder.Services.AddScoped<IRecipeItemRepository, RecipeItemRepository>();
        builder.Services.AddScoped<IItemPositionRepository, ItemPositionRepository>();
        builder.Services.AddScoped<IGuildRepository, GuildRepository>();
        builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
        app.UseCors("AllowSpecificOrigins");

        app.MapControllers();

        app.Run();
    }
}
