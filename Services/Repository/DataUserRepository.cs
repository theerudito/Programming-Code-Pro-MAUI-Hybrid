using ProgrammingCodePro.Helpers;
using System.Net;

namespace ProgrammingCodePro.Services.Repository
{
    public class DataUserRepository(ApiManager _api)
    {
        private HttpClient _http = new HttpClient();

        public async Task<bool> DeleteDataUser(int idUserDto)
        {
            try
            {
                var res = await _http.DeleteAsync($"{_api.url}/api/v1/DataUser/{idUserDto}");

                if (res.StatusCode != HttpStatusCode.OK) return false;
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }
    }
}
