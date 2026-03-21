using Microsoft.AspNetCore.Mvc;
using task_2.Application.Contract;
using task_2.Application.Dtos.Course;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

   
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _courseService.GetAllCourses());

    [HttpPost]
    public async Task<IActionResult> Post(CourseDto courseDto)
    {
        try
        {
            await _courseService.AddCourse(courseDto);
            return Ok("Curso agregado correctamente.");
        }
        catch (ArgumentException ex)
        {
            
            return BadRequest(ex.Message);
        }
    }
}