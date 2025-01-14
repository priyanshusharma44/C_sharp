namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            

           app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
