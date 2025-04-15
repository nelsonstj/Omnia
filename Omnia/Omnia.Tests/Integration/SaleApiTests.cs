using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Omnia.Domain.Entities;
using Omnia.Tests.Domain.Helpers;
using System.Net.Http.Json;
using System.Text;

namespace Omnia.Tests.Integration;

public class SaleApiTests : IClassFixture<TestStartupFactory>
{
	private readonly HttpClient _client;

	public SaleApiTests(TestStartupFactory factory)
	{
		TestDataCleaner.ClearTestData();
		_client = factory.CreateClient();
	}

	[Fact]
	public async Task Should_Create_Sale_Successfully()
	{
		var newSale = new Sale
		{
			SaleNumber = "0",
			Customer = "Cliente Nicolas",
			Branch = "Filial B",
			SaleDate = DateTime.Now,
		};

		newSale.AddItem(new SaleItem("Produto J", 5, 100));

		var content = new StringContent(JsonConvert.SerializeObject(newSale), Encoding.UTF8, "application/json");

		var response = await _client.PostAsync("/api/sales", content);

		response.EnsureSuccessStatusCode();
		var json = await response.Content.ReadAsStringAsync();
		Assert.NotNull(json);
		//Assert.Contains("S0005", json);
	}

	[Fact]
	public async Task Should_Get_All_Sales()
	{
		var response = await _client.GetAsync("/api/sales/all");
		response.EnsureSuccessStatusCode();

		var sales = await response.Content.ReadFromJsonAsync<List<Sale>>();
		Assert.NotNull(sales);
	}
}
