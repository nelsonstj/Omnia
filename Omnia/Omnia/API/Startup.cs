using Omnia.Application.Services;
using Omnia.Domain.Interfaces;
using Omnia.Infrastructure.Persistence;
using System.Text.Json;

namespace Omnia.API
{
	public class Startup(IConfiguration configuration)
	{
		public IConfiguration Configuration { get; } = configuration;

		public void ConfigureServices(IServiceCollection services)
		{
			// Configurações do MVC
			services.AddControllers();

			// Configura JSON Serializer para evitar referências circulares
			services.AddMvc()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
					options.JsonSerializerOptions.WriteIndented = true;
				});

			// Injeção de dependência
			services.AddSingleton<ISaleRepository, FileSaleRepository>(); // Repositório baseado em arquivos
			services.AddSingleton<CustomerRepository>();
			services.AddSingleton<BranchRepository>();
			services.AddSingleton<ProductRepository>(); 
			
			services.AddScoped<SaleService>();

			// Configuração do Swagger para documentação da API
			services.AddSwaggerGen();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Ativa o Swagger UI
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales API v1"));

			app.UseRouting();

			// Habilita CORS (se necessário)
			app.UseCors(policy =>
				policy.AllowAnyOrigin()
					  .AllowAnyMethod()
					  .AllowAnyHeader());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}