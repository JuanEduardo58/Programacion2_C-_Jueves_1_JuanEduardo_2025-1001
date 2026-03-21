using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Infrastructure.Context;
using School.Infrastructure.Interfaces;

namespace School.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAll() => await _context.Courses.ToListAsync();

        public async Task<Course?> GetById(int id) => await _context.Courses.FindAsync(id);

        public async Task Add(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var course = await GetById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}