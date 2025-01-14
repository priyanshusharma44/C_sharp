namespace CRUDWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a web application builder (initial setup)
            var builder = WebApplication.CreateBuilder(args);
            // Register services for MVC (Controller + Views)
            builder.Services.AddControllersWithViews();
            // Build the application (creates the app pipeline)
            var app = builder.Build();
            //heps to create route ...dotnet have its default route
/*            app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
            app.MapDefaultControllerRoute();


            //to use bootstrap we need static file access  wwwroot
            app.UseStaticFiles();
            app.Run();
        }
    }
}
