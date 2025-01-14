namespace Bca2081MVCEmpty
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

            // Enable routing and map default route (controller/action/id)
            // app.MapDefaultControllerRoute();

            //to change default route disable above MapDefaultControllerROute then code below
            app.MapControllerRoute(name: "myRoute", pattern: "{controller=Home}/{action=Hello}/{id?}");

            //to give permisiion of bootstraps in wwwroot
            app.UseStaticFiles();
            // Run the application
            app.Run();
        }
    }
}
