using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using System.Text;

namespace ProgrammingCodePro.Service.Repository
{
	public class ImagesClassRepository(ApiManager _api)
	{
		private HttpClient _http = new HttpClient();
		
		public async Task<List<ImagesClassDto>> GetImagesClass(string nameCourseDto)
		{
			try
			{
				var response = await _http.GetAsync($"{_api.url}/api/v1/ImageClass");

				var json = await response.Content.ReadAsStringAsync();

				var order = JsonConvert.DeserializeObject<List<ImagesClassDto>>(json)!;

				order = order.OrderBy(x => x.IdImageClass).ToList();

				return order;

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return new List<ImagesClassDto>();
			}
		}

		public async Task<bool> PostImageClass(ImagesClassDto myImageClassDto)
		{
			try
			{
				var json = JsonConvert.SerializeObject(myImageClassDto);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await _http.PostAsync($"{_api.url}/api/v1/ImageClass", content);

				return response.IsSuccessStatusCode == true ? true : false;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

	}
}