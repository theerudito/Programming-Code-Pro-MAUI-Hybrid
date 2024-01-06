using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using ProgrammingCodePro.Service.Interface;
using System.Net;
using System.Net.Http.Json;

namespace ProgrammingCodePro.Service.Repository
{
	public class AuthRepository(ApiManager _api) : IAuth
	{
		private HttpClient _http = new HttpClient();
		
		public async Task<bool> RegisterAuth(AuthDto userDto)
		{
			try
			{
      

                var res = _http.PostAsJsonAsync($"{_api.url}/api/v1/Auth/register", userDto);

				var data = await res.Result.Content.ReadAsStringAsync();

				var json = JsonConvert.DeserializeObject<AuthDto>(data);

				if (res.Result.StatusCode == HttpStatusCode.OK)
				{
					LocalStorageDataApp.SetItem(LocalStorageDataApp.KeyUser, json.Name);
					LocalStorageDataApp.SetItem(LocalStorageDataApp.KeyToken, json.Token);
					LocalStorageDataApp.SetItem(LocalStorageDataApp.KeyIdUser, json.IdUser.ToString());
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		}

		public async Task<bool> LoginAuth(AuthDto userDto)
		{
			try
			{
				var res = _http.PostAsJsonAsync($"{_api.url}/api/v1/Auth/login", userDto);

				var data = await res.Result.Content.ReadAsStringAsync();

				var json = JsonConvert.DeserializeObject<AuthDto>(data);

				if (res.Result.StatusCode == HttpStatusCode.OK)
				{
					LocalStorageDataApp.SetItem(LocalStorageDataApp.KeyUser, json.Name);
					LocalStorageDataApp.SetItem(LocalStorageDataApp.KeyToken, json.Token);
					LocalStorageDataApp.SetItem(LocalStorageDataApp.KeyIdUser, json.IdUser.ToString());

					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		}
	}
}