
using asmgd2_maivanminh.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration; // Import namespace của WebsiteLazadaContext


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; } // Thêm biến cấu hình vào lớp Startup

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<WebsiteLazadaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); // Sử dụng biến cấu hình

        // Các dịch vụ khác...

        services.AddControllersWithViews();
        services.AddSession();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession(); // Kích hoạt Session

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}