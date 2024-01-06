using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using System.Text;

namespace ProgrammingCodePro.Service.Repository
{
    public class MyClassRepository(ApiManager _api)
    {
        private HttpClient _http = new HttpClient();
       
        public async Task<List<MyClassDto>> GetMyClass()
        {
            try
            {
                var response = await _http.GetAsync($"{_api.url}/api/v1/MyClass");

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<MyClassDto>>(json)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MyClassDto>();
            }
        }

        public async Task<List<MyClassDto>> FindMyClass(int IdCourseDto, int IdTypeDto)
        {
            try
            {
                var response = await _http.GetAsync($"{_api.url}/api/v1/MyClass/courseType/{IdCourseDto}/{IdTypeDto}/");

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<MyClassDto>>(json)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MyClassDto>();
            }
        }

        public async Task<bool> PostMyClass(MyClassDto myClassDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(myClassDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _http.PostAsync($"{_api.url}/api/v1/MyClass", content);

                return response.IsSuccessStatusCode == true ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        public async Task<bool> PutMyClass(MyClassDto myClassDto, int idClassDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(myClassDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _http.PutAsync($"{_api.url}/api/v1/MyClass/{idClassDto}", content);

                return response.IsSuccessStatusCode == true ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return true;
            }
        }

        public async Task<List<MyClassDto>> SeachingClass(string seachClassDto)
        {
            try
            {
                var response = await _http.GetAsync($"{_api.url}/api/v1/MyClass/searchMyClass/{seachClassDto}");

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<MyClassDto>>(json)!;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MyClassDto>();
            }
        }

    }
}