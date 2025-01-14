using TestingRestfulApi.Models;
using Microsoft.EntityFrameworkCore;
namespace TestingRestfulApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<StudentDbContext>(option=>option.UseSqlServer(
                
                 builder.Configuration.GetConnectionString("Con1")
                ));

            //for web api now no view needed only controllers so Addcontrollers
            builder.Services.AddControllers();
            var app = builder.Build();
            //to end point direct connection ..we use custome route
            app.UseRouting();
            app.UseStaticFiles();
            app.MapControllers();
            app.Run();
        }
    }
}
