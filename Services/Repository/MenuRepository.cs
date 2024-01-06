using Newtonsoft.Json;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using ProgrammingCodePro.Service.Interface;
using System.Text;

namespace ProgrammingCodePro.Service.Repository
{
	public class MenuRepository(ApiManager _api) : IMenu
	{
		private HttpClient _http = new HttpClient();
		
		public async Task<List<MenuDto>> GetMenu(int idRoleDto)
		{
			try
			{
				var res = await _http.GetAsync($"{_api.url}/api/v1/Menu/menu/{idRoleDto}");

				var json = res.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<List<MenuDto>>(json)!;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return new List<MenuDto>();
			}
		}

		public async Task<bool> PostMenus(List<MenuDto> MenuDto)
		{
			try
			{
				var json = JsonConvert.SerializeObject(MenuDto);

				var content = new StringContent(json, Encoding.UTF8, "application/json");

				var res = await _http.PostAsync($"{_api.url}/api/v1/Menu/menu", content);

				return res.IsSuccessStatusCode == true ? true : false;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}
		}
	}
}