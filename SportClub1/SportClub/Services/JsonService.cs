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
		private readonly JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };
		public async Task ExportAsync<T>(IEnumerable<T> data, string filePath)
		{
			await using var fs = File.Create(filePath);
			await JsonSerializer.SerializeAsync(fs, data, _options);
		}
		public async Task<IEnumerable<T>> ImportAsync<T>(string filePath)
		{
			await using var fs = File.OpenRead(filePath);
			return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(fs, _options) ?? Enumerable.Empty<T>();
		}
	}
}
