using CommunicationWebApi.Data;
using CommunicationWebApi.Services;
using Microsoft.EntityFrameworkCore;

namespace CommunicationWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddDbContext<CommunicationDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("CommunicationWebApiContext")
            //    ?? throw new InvalidOperationException("Connection string 'CommunicationWebApiContext' not found.")));

            builder.Services.AddSqlite<CommunicationDbContext>(builder.Configuration.GetConnectionString("CommunicationDbContext"));
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<MessageService>();
            builder.Services.AddScoped<ChatRoomService>();

            var app = builder.Build();

            // custom seeding
            app.CreateDB();

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
        }
    }
}