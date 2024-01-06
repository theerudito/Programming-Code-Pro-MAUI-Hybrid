using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;

namespace ProgrammingCodePro.Service.Repository
{
	public class CourseTypesRepository(ApiManager _api)
	{
		private HttpClient _http = new HttpClient();
		
		public async Task<List<TypeCourseDto>> GetTypes()
		{
			try
			{
				var response = await _http.GetAsync($"{_api.url}/api/v1/TypeCourse");

				var json = await response.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<List<TypeCourseDto>>(json)!;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return new List<TypeCourseDto>();
			}
		}

	}
}