using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using ProgrammingCodePro.Service.Interface;
using System.Text;

namespace ProgrammingCodePro.Service.Repository
{
    public class ApplicationRepository(ApiManager _api) : IMyApplication
    {
        private HttpClient _http = new HttpClient();

       
        public async Task<List<ApplicationDto>> GetDataApplication(int idUserDto)
        {
            try
            {
                var res = await _http.GetAsync($"{_api.url}/api/v1/Application/applicationUser/{idUserDto}");

                var json = res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<ApplicationDto>>(json)!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<ApplicationDto>();
            }
        }

        public async Task<bool> PostDataApplication(ApplicationDto myApplicationDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(myApplicationDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await _http.PostAsync($"{_api.url}/api/v1/Application", content);

                return res.IsSuccessStatusCode == true ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> PutDataApplication(ApplicationDto myApplicationDto, int idApplicationDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(myApplicationDto);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await _http.PutAsync($"{_api.url}/api/v1/Application/{idApplicationDto}", content);

                return res.IsSuccessStatusCode == true ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> LikeCourse(int idApplicationDto)
        {
            try
            {
                var res = await _http.PatchAsync($"{_api.url}/api/v1/Application/likeCourse/{idApplicationDto}", null);

                return res.IsSuccessStatusCode == true ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> ScoreCourse(int idApplicationDto)
        {
            try
            {
                var res = await _http.PatchAsync($"{_api.url}/api/v1/Application/scoreCourse/{idApplicationDto}", null);

                return res.IsSuccessStatusCode == true ? true : false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<List<ApplicationDto>> SearchingMyApplication(string seachDataDto, int idUserDto)
        {
            try
            {
                var res = await _http.GetAsync($"{_api.url}/api/v1/Application/searchApplication/{seachDataDto.ToUpper()}/{idUserDto}");

                var json = res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<ApplicationDto>>(json)!;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<ApplicationDto>();
            }
        }
    }
}