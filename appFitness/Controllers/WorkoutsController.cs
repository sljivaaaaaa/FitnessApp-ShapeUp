using appFitness.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace appFitness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public WorkoutsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetWorkouts()
        {
            var workouts = _dbContext.Workouts
                .Include(w => w.WorkoutImages)
            
                .ToList();

            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkoutDetails(int id)
        {
            var workout = _dbContext.Workouts
                .Include(w => w.WorkoutImages)
                .Include(w => w.WorkoutLinks)
                .FirstOrDefault(w => w.WorkoutId == id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }


        [HttpGet("with-images")]
        public IActionResult GetWorkoutsWithImages()
        {
            var workoutsWithImages = _dbContext.Workouts
                .Include(w => w.WorkoutImages)
                .Where(w => w.WorkoutImages.Any())
                .ToList();

            return Ok(workoutsWithImages);
        }

        [HttpGet("with-links")]
        public IActionResult GetWorkoutsWithLinks()
        {
            var workoutsWithLinks = _dbContext.Workouts
                .Include(w => w.WorkoutLinks)
                .Where(w => w.WorkoutLinks.Any())
                .ToList();

            return Ok(workoutsWithLinks);
        }
    }
}
