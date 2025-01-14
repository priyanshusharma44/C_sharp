using Microsoft.EntityFrameworkCore;
using StudentAppWithLogin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace StudentAppWithLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //addauthenticate after doing all thing ....at ending times
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => { option.LoginPath = "/UserList/Login"; });  


            //database and code middle thing ....dependecny injectioin things comes from here
            //controller parameter using
            builder.Services.AddDbContext<StudentDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("Con1")));
            //folder structure
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseRouting();
            //secure page to make we need to do this below 2 thing auth and authorization
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(name: "Myroute",pattern:"{controller=UserList}/{action=Login}/{id?}");
            app.Run();
            //we do sqlserver,and tools as well
        }
    }
}
