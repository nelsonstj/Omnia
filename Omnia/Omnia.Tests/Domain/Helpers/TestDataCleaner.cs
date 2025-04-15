namespace Omnia.Tests.Domain.Helpers
{
	public static class TestDataCleaner
	{
		private static readonly string[] TestFiles = new[]
		{
			"Infrastructure/Persistence/sales_test.json",
			"Infrastructure/Persistence/customers_test.json",
			"Infrastructure/Persistence/branches_test.json",
			"Infrastructure/Persistence/products_test.json"
		};

		public static void ClearTestData()
		{
			foreach (var file in TestFiles)
			{
				if (File.Exists(file))
				{
					File.WriteAllText(file, "[]");
				}
			}
		}
	}
}