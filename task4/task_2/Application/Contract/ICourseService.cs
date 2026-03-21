using task_2.Application.Dtos.Course;

namespace task_2.Application.Contract
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllCourses();
        Task AddCourse(CourseDto courseDto);
    }
}