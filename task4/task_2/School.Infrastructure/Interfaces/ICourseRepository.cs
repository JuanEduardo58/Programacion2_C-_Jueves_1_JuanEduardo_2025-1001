namespace task_2.School.Infrastructure.Interfaces
using School.Domain.Entities;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course?> GetById(int id);
        Task Add(Course course);
        Task Delete(int id);
    }
}
