
using DevNet.Middleware;
using DevNet.Repasitories.Post;
using DevNet.Repasitories.Quesion;
using DevNet.Repasitories.Topic;
using Microsoft.EntityFrameworkCore;

namespace DevNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddLocalization();
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
           

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );
            builder.Services.AddScoped<IPost,PostService>();
            builder.Services.AddScoped<IQuesion, QuesionService>();
            builder.Services.AddScoped<ITopic, TopicService>();

            var app = builder.Build();

      
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            var supportedCultures = new[] { "en-US", "hy-AM" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture("en")
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
            app.UseRequestLocalization(localizationOptions);
            app.UseMiddleware<LocalizationMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapHub<Hubb.ChatHub>("/chatHub");
            app.Run();
        }
    }
}
