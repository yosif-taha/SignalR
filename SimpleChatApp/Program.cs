using Microsoft.EntityFrameworkCore;
using SimpleChatApp.Hubs;
using SimpleChatApp.Models.Data;

namespace SimpleChatApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register the SignalR hub
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<ChatContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            // Map the SignalR hub : implementation of Url for the hub
            app.MapHub<ChatHub>("/chat");
            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=chat}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
