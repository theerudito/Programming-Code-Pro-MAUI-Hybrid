using Microsoft.AspNetCore.Components;
using ProgrammingCodePro.Helpers;
using ProgrammingCodePro.Models;
using ProgrammingCodePro.Service.Another;
using ProgrammingCodePro.Service.Interface;

namespace ProgrammingCodePro.Pages.CourseList
{
	public partial class Courses
	{
		private string IdUser = "";

		[Inject]
		private LanguageService LanguageService { get; set; } = null!;

		[Inject]
		private NavigationManager Navigation { get; set; } = null!;

		[Inject]
		private IMyApplication ApplicationRepository { get; set; } = null!;

		[Inject]
		private ICourse CourseRepository { get; set; } = null!;

		private List<CourseDto> _listCourse = new List<CourseDto>();

		private List<ApplicationDto> _myApplication = new List<ApplicationDto>();

		protected override async Task OnInitializedAsync()
		{
			LanguageService.ChangeLanguage += StateHasChanged;

			MyVariablesApp._displayInput = "d-none";

			IdUser = await LocalStorageDataApp.GetItem(LocalStorageDataApp.KeyIdUser);

			_listCourse = await CourseRepository.GetsCourses();

			_myApplication = await ApplicationRepository.GetDataApplication(Convert.ToInt32(IdUser));
		}

		public async void ReloadData()
		{
			await OnInitializedAsync();
			this.StateHasChanged();
		}

		public async Task SearchMyCourse(ChangeEventArgs e)
		{
			MyVariablesApp._searchData = e.Value.ToString();

			var infor = await ApplicationRepository.SearchingMyApplication(MyVariablesApp._searchData!, (Convert.ToInt32(IdUser)));

			if (infor == null)
			{
				_myApplication = await ApplicationRepository.GetDataApplication(Convert.ToInt32(IdUser));
			}
			else
			{
				_myApplication = infor;
			}
		}

		private void ShowInput()
		{
			if (MyVariablesApp._isSeaching == false)
			{
				MyVariablesApp._displayInput = "d-flex";
				MyVariablesApp._isSeaching = true;
			}
			else
			{
				MyVariablesApp._displayInput = "d-none";
				MyVariablesApp._isSeaching = false;
			}
		}

		private async void LikeCourse(int idApplication)
		{
			await ApplicationRepository.LikeCourse(idApplication);
			ReloadData();
		}

		private void NavigateMyClass(ApplicationDto Application)
		{
			Navigation.NavigateTo($"/myclass/{Application.IdApplication}/{Application.IdCourse}/{Application.IdType}");
		}

		private async void SelectCourse(CourseDto myCourse)
		{
			var myNewCourse = new ApplicationDto
			{
				IdUser = Convert.ToInt32(IdUser),
				IdCourse = myCourse.IdCourse,
				IdType = myCourse.IdType,
				Title = myCourse.Name,
				ScoreCourse = 0,
				LikeCourse = false,
				ImageUrl = myCourse.ImageUrl,
				ImageBase64 = myCourse.ImageBase64,
				RefImage = myCourse.RefImage,
			};

			var courseApplication = await ApplicationRepository.PostDataApplication(myNewCourse);

			if (courseApplication == true)
			{
				await CourseRepository.SelectedCourse(myCourse.IdCourse);
				await CloseModal();
			}
			else
			{
				await CloseModal();
			}
			ReloadData();
		}

		private Task OpenModal() => MyVariablesApp.ModalCourseList.Show();

		private Task CloseModal() => MyVariablesApp.ModalCourseList.Hide();

		public void Dispose()
		{
			LanguageService.ChangeLanguage -= StateHasChanged; ;
		}
	}
}