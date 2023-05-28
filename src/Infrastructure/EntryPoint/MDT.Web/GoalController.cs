using MDT.Model.Data;
using MDT.UseCase.Goals;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MDT.Web
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowOrigin")]
    public class GoalController : ControllerBase
    {

        private readonly IGoalUseCase goalUseCase;

        public GoalController(IGoalUseCase goalUseCase)
        {
            this.goalUseCase = goalUseCase;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetGoals()
        {
            var goals = new
            {
                goals = await goalUseCase.GetGoals()
            };

            return Ok(goals);
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Goal>> GetGoalById(int goalId)
        {
            try
            {
                if (goalId < 1)
                    return BadRequest();

                var result = await goalUseCase.GetGoalById(goalId);

                if (result == null)
                    return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving goal record");
            }
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetGoalsByUserId(string userId)
        {
            var goals = new
            {
                goals = await goalUseCase.GetGoalsByUser(userId)
            };

            return Ok(goals);
        }


        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Goal>> CreateGoal([FromBody] Goal goal)
        {
            try
            {
                if (goal == null)
                    return BadRequest();

                var createdGoal = await goalUseCase.AddGoal(goal);

                return createdGoal;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new goal record");
            }
        }


        [HttpPut]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Goal>> UpdateGoal([FromBody] Goal goal)
        {
            try
            {
                if (goal == null || goal.Id < 1)
                    return BadRequest();

                var createdGoal = await goalUseCase.UpdateGoal(goal);

                return createdGoal;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating goal record");
            }
        }

        [HttpDelete]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteGoalById(int goalId)
        {
            try
            {
                if (goalId < 1)
                    return BadRequest();

                await goalUseCase.DeleteGoalById(goalId);
                return Ok();
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating goal record");
            }
        }

    }
}
