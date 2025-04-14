using Newtonsoft.Json;

namespace Omnia.Infrastructure.Persistence
{
    public class BaseFileRepository<T>(string filePath)
	{
        private readonly string _filePath = filePath;

		protected List<T> LoadData()
        {
            if (!File.Exists(_filePath))
                return [];

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? [];
        }

        protected void SaveData(List<T> data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}