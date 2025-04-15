using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Omnia.API;

namespace Omnia.Tests.Integration;

public class TestStartupFactory : WebApplicationFactory<Startup>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureAppConfiguration((context, configBuilder) =>
		{
			configBuilder
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false)
				.AddJsonFile("appsettings.Test.json", optional: true);
		});
	}
}
