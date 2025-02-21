using LearningCourseWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningCourseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly LearningCourseWebApiContext dbContext;

        public StudentController(LearningCourseWebApiContext DbContext)
        {
            dbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await dbContext.Students.ToListAsync();
            return Ok(data);

        }
    }
}
