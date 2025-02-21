using LearningCourseWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningCourseWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly LearningCourseWebApiContext dbContext;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(LearningCourseWebApiContext DbContext, ILogger<CoursesController> logger)
        {
            dbContext = DbContext;
            _logger = logger;
        }



        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            _logger.LogInformation("Fetching all Courses.");
            var data = await dbContext.Courses.ToListAsync();
            return Ok(data);

        }

        // GET: api/courses/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            //_logger.LogInformation("Fetching Course with ID: {Id}", id);
            var course = await dbContext.Courses.FindAsync(id);

            if (course == null)
            {
                _logger.LogWarning("Course with ID: {Id} not found.", id);
                return NotFound();
            }

            return course;
        }

        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            _logger.LogInformation("Creating a new Course.");
            dbContext.Courses.Add(course);
            await dbContext.SaveChangesAsync();
            return Ok(course);
            //return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }




        // PUT: api/courses
        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(int id, Course course)
        {
            _logger.LogInformation("Updating Course with ID: {Id}", id);
            if (id != course.Id)
            {
                _logger.LogWarning("Course with ID: {Id} not found.", id);
                return BadRequest();
            }
            dbContext.Entry(course).State = EntityState.Modified;
            dbContext.SaveChanges();
            return Ok(course);
        }

        // DELETE: api/courses
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            _logger.LogInformation("Deleting course with ID: {Id}", id);
            var course = await dbContext.Courses.FindAsync(id);
            if (id == null)
            {
                _logger.LogWarning("Course with ID: {Id} not found.", id);
                return NotFound();
            }
              dbContext.Courses.Remove(course);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
