using ProgrammingCodePro.Models;

namespace ProgrammingCodePro.Service.Interface
{
    public interface ICourse
    {
        Task<List<CourseDto>> GetsCourses();
        Task<CourseDto> GetCourseId(int idCourseDto);
        Task<bool> PostCourse(CourseDto courseDto);
        Task<bool> PutCourse(CourseDto courseDto, int idCourseDto);
        Task<bool> SelectedCourse(int idCourseDto);
        Task<List<CourseDto>> SearchingCourse(string searchCourse);
    }
}
