using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using System.Text;

namespace ProgrammingCodePro.Service.Repository
{
    public class My_Class_Repository(ApiManager _api)
    {
        private HttpClient _http = new HttpClient();
       
        public async Task<bool> PostData(int idUser, int idCourse, int idClass)
        {
            var json = JsonConvert.SerializeObject(new MyClass_Dto { IdClass = idClass, IdCourse = idCourse, IdUser = idUser });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _http.PostAsync($"{_api.url}/api/v1/My_Class", content);

            return res.IsSuccessStatusCode == true ? true : false;
        }
    }
}