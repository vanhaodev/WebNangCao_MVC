using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNangCao_MVC.Controllers;
using WebNangCao_MVC.Models.Auth;
using WebNangCao_MVC.Models.Idol;

namespace WebNangCao_MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AuthController.users.Add(new UserLogin("vanhaodev", "vanhaodev", UserRole.Admin));
            AuthController.users.Add(new UserLogin("nvh2001", "nvh2001", UserRole.None));


            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Shin Ryujin", "https://file.tinnhac.com/2020/06/04/20200604182631-31d6.jpg", "Sinh năm 2001"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Shin Yuna", "https://qph.cf2.quoracdn.net/main-qimg-37565cd1e10f0379eccb6656948b8f0d-lq", "Sinh năm 2003"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Lee Chaeryeong", "https://static1.bestie.vn/Mlog/ImageContent/202208/tu-my-nhan-mo-nhat-nhan-sac-chaeryeong-itzy-no-ro-body-sieu-thuc-ea2d67.jpg", "Sinh năm 2001"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Choi Jisoo", "https://file.tinnhac.com/resize/600x-/2021/06/16/20210616101253-51ec.jpg", "Sinh năm 2000"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Hwang Yeji", "https://i.ibb.co/nPz1dY4/truong-nhom-yejin.jpg", "Sinh năm 2000"));

            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Lily Jin Morrow", "https://znews-photo.zingcdn.me/w660/Uploaded/qfssu/2022_02_24/274586236_159371359771135_2029326590285049125_n.jpg", "Sinh năm 2002"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Oh Haewon", "https://znews-photo.zingcdn.me/w660/Uploaded/ofh_btgazsox/2022_03_21/220225_NMIXX_Twitter_Update_Happy_Birthday_Haewon_documents_7.jpeg", "Sinh năm 2003"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Seol Yoona", "https://static2.yan.vn/YanNews/2167221/202203/nhung-khoanh-khac-chung-minh-visual-dang-cap-cua-sullyoon-nmixx-28f61b52.jpg", "Sinh năm 2004"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Choi Yunjin", "https://pbs.twimg.com/media/FLZtNjxVIAIj_t8?format=jpg&name=4096x4096", "Sinh năm 2004"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Bae Jinsol", "http://images6.fanpop.com/image/photos/44300000/Bae-nmixx-44361667-1080-1350.jpg", "Sinh năm 2004"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Kim Jiwoo", "https://static.wikia.nocookie.net/kpop/images/8/89/NMIXX_Jiwoo_Entwurf_concept_photo_1.png", "Sinh năm 2005"));
            IdolController.idols.Add(new IdolProfile(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "Jang Kyujin", "https://kpopnews.atsit.in/vi/wp-content/uploads/2022/02/nmixx-kyujin-thu-hut-su-chu-y-vi-co-nhung-dac-diem-tuong-tu-nhu-hai-nghe-si-nay-cua-jyp-1.jpg", "Sinh năm 2006"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //===================SESSION===============//
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });
            services.AddMvc();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //===========================================//

            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //===================SESSION===============//
            app.UseSession();
            //========================================//
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute(
                //    name: "auth",
                //    pattern: "{controller=AuthController}/{action=Login}/{id?}");

            });
        }
    }
}
