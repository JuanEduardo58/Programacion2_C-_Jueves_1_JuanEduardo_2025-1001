using task_2.Application.Contract;
using task_2.Application.Dtos.Course;
using task_2.Domain.Entities;
using task_2.Infrastructure.Interfaces;
using task_2.School.Infrastructure.Interfaces.School.Infrastructure.Interfaces;

namespace task_2.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var courses = await _repository.GetAll();

            // Transformamos la Entidad del Dominio al DTO de la Aplicación
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits
            });
        }

        public async Task AddCourse(CourseDto courseDto)
        {
            // === VALIDACIONES OBLIGATORIAS DE LA TAREA ===
            if (string.IsNullOrWhiteSpace(courseDto.Title))
                throw new ArgumentException("Error: El título del curso no puede estar vacío.");

            if (courseDto.Credits <= 0)
                throw new ArgumentException("Error: Los créditos del curso deben ser mayores a 0.");

            // Si pasa las validaciones, lo convertimos a Entidad y lo guardamos
            var course = new Course
            {
                Title = courseDto.Title,
                Credits = courseDto.Credits
            };

            await _repository.Add(course);
        }
    }
}