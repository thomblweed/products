using API.Config;
using API.Data;
using API.Data.Seed;
using API.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.Configure<ProductsStoreDatabaseSettings>(
                _config.GetSection(nameof(ProductsStoreDatabaseSettings)));
            services.AddSingleton<IProductsStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ProductsStoreDatabaseSettings>>().Value);
            services.AddSingleton<ProductService>();

            services.AddControllers();
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IProductsStoreDatabaseSettings productsStoreDatabaseSettings)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products Api");
            });

            if (env.IsDevelopment())
            {
                SeedProducts seed = new SeedProducts(productsStoreDatabaseSettings);
                await seed.SeedDataAsync();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
