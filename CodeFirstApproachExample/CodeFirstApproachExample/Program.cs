using CodeFirstApproachExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproachExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MyDbcontext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("Con1")));
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.MapControllerRoute(name: "myRoute", pattern: "{controller=Home}/{action=Index}/{id?}");
            
            
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
