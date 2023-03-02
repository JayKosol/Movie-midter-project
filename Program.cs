
using Movie.Data;

namespace Movie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<appDbContext>();
            var app = builder.Build();
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions(Path.Combine(builder.Environment.ContentRootPath,)))

            //app.MapGet("/");
            app.UseRouting();
            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}