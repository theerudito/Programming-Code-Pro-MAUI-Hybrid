using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using System.Text;

namespace ProgrammingCodePro.Service.Repository
{
	public class ImagesCoursesRepository(ApiManager _api)
	{
		private HttpClient _http = new HttpClient();
		
		public async Task<List<ImagesCourseDto>> GetImagesCourses()
		{
			try
			{
				var response = await _http.GetAsync($"{_api.url}/api/v1/ImageCourse");

				var json = await response.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<List<ImagesCourseDto>>(json)!;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return new List<ImagesCourseDto>();
			}
		}

		public async Task<bool> PostImageCourse(ImagesCourseDto myImageCourseDto)
		{
			try
			{
				var json = JsonConvert.SerializeObject(myImageCourseDto);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await _http.PostAsync($"{_api.url}/api/v1/ImageCourse", content);

				return response.IsSuccessStatusCode == true ? true : false;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		}

	}
}