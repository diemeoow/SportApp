using SportClub.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportClub.Services
{
    public class JsonService : IJsonService
    {
        public async Task ExportAsync<T>(IEnumerable<T> data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task<IEnumerable<T>> ImportAsync<T>(string filePath)
        {
            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<IEnumerable<T>>(json);
        }
    }
}
