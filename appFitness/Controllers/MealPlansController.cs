using appFitness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFitness.Data;

namespace appFitness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealPlansController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public MealPlansController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/MealPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealPlan>>> GetMealPlans()
        {
            var mealPlans = await _dbContext.MealPlans
                .Include(mp => mp.Days) // Include associated MealPlanDays
                .ToListAsync();

            return mealPlans;
        }


        // GET: api/MealPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealPlan>> GetMealPlan(int id)
        {
            var mealPlan = await _dbContext.MealPlans
                .Include(mp => mp.Days) // Include associated MealPlanDays
                .FirstOrDefaultAsync(mp => mp.PlanId == id);

            if (mealPlan == null)
            {
                return NotFound();
            }

            return mealPlan;
        }


        // POST: api/MealPlans
        [HttpPost]
        public async Task<ActionResult<MealPlan>> PostMealPlan(MealPlan mealPlan)
        {
            _dbContext.MealPlans.Add(mealPlan);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMealPlan), new { id = mealPlan.PlanId }, mealPlan);
        }

        // PUT: api/MealPlans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealPlan(int id, MealPlan mealPlan)
        {
            if (id != mealPlan.PlanId)
            {
                return BadRequest();
            }

            _dbContext.Entry(mealPlan).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/MealPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealPlan(int id)
        {
            var mealPlan = await _dbContext.MealPlans.FindAsync(id);
            if (mealPlan == null)
            {
                return NotFound();
            }

            _dbContext.MealPlans.Remove(mealPlan);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool MealPlanExists(int id)
        {
            return _dbContext.MealPlans.Any(e => e.PlanId == id);
        }
    }
}
