using Microsoft.EntityFrameworkCore;
using EFCORECRUDASP.Models;
namespace EFCORECRUDASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ToDoAppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon")));


            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();
            //app.MapControllerRoute(name: "myRoute", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
