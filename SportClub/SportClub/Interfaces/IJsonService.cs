using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Interfaces
{
	public interface IJsonService
	{
		Task ExportAsync<T>(IEnumerable<T> data, string filePath);
		Task<IEnumerable<T>> ImportAsync<T>(string filePath);
	}
}
