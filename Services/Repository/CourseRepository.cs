using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using ProgrammingCodePro.Service.Interface;
using System.Text;

namespace ProgrammingCodePro.Service.Repository
{
	public class CourseRepository(ApiManager _api) : ICourse
	{
		private HttpClient _http = new HttpClient();

		public async Task<List<CourseDto>> GetsCourses()
		{
			try
			{
				var res = await _http.GetAsync($"{_api.url}/api/v1/Course");

				var json = res.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<List<CourseDto>>(json)!;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message.ToString());
				return new List<CourseDto>();
			}
		}

        public async Task<CourseDto> GetCourseId(int idCourseDto)
        {
            try
            {
                var res = await _http.GetAsync($"{_api.url}/api/v1/Course/{idCourseDto}");

                var json = res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<CourseDto>(json)!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new CourseDto();
            }
        }

        public async Task<bool> PostCourse(CourseDto courseDto)
		{
			try
			{
				var json = JsonConvert.SerializeObject(courseDto);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var res = await _http.PostAsync($"{_api.url}/api/v1/Course", content);

				return res.IsSuccessStatusCode == true ? true : false;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		}

		public async Task<bool> PutCourse(CourseDto courseDto, int idCourseDto)
		{
			try
			{
				var json = JsonConvert.SerializeObject(courseDto);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var res = await _http.PutAsync($"{_api.url}/api/v1/Course/{idCourseDto}", content);

				return res.IsSuccessStatusCode == true ? true : false;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		}

		public async Task<bool> SelectedCourse(int idCourseDto)
		{
			try
			{
				var res = await _http.PatchAsync($"{_api.url}/api/v1/Course/selectedCourse/{idCourseDto}", null);

				return res.IsSuccessStatusCode == true ? true : false;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		}

		public async Task<List<CourseDto>> SearchingCourse(string searchCourseDto)
		{
			try
			{
				var res = await _http.GetAsync($"{_api.url}/api/v1/Course/searchCourse/{searchCourseDto}");

				var json = res.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<List<CourseDto>>(json)!;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return new List<CourseDto>();
			}
		}
      
    }
}