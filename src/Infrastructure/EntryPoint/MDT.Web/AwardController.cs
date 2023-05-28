using MDT.Model.Data;
using MDT.UseCase.Awards;
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
    public class AwardController : ControllerBase
    {
        private readonly IAwardUseCase awardUseCase;

        public AwardController(IAwardUseCase awardUseCase)
        {
            this.awardUseCase = awardUseCase;
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAwards()
        {
            var award = new
            {
                award = await awardUseCase.GetAwards()
            };

            return Ok(award);
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAwardById(int awardId)
        {
            try
            {
                if (awardId < 1)
                    return BadRequest();

                var award = new
                {
                    award = await awardUseCase.GetAwardById(awardId)
                };

                return Ok(award);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving award record");
            }
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAwardsByGoalId(long goalId)
        {
            try
            {
                if (goalId < 1)
                    return BadRequest();

                var award = new
                {
                    award = await awardUseCase.GetAwardsByGoal(goalId)
                };

                return Ok(award);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving award records by goalId");
            }
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAwardsByUserId(string userId)
        {
            try
            {
                if (userId == null)
                    return BadRequest();

                var award = new
                {
                    award = await awardUseCase.GetAwardsByUser(userId)
                };

                return Ok(award);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving award records by userId");
            }
        }


        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Award>> CreateAward([FromBody] Award award)
        {
            try
            {
                if (award == null)
                    return BadRequest();

                var createdAward = await awardUseCase.AddAward(award);

                return createdAward;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new award record");
            }
        }


        [HttpPut]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Award>> UpdateAward([FromBody] Award award)
        {
            try
            {
                if (award == null || award.Id < 1)
                    return BadRequest();

                var updatedAward = await awardUseCase.UpdateAward(award);

                return updatedAward;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating award record");
            }
        }


        [HttpDelete]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteAwardById(int awardId)
        {
            try
            {
                if (awardId < 1)
                    return BadRequest();

                await awardUseCase.DeleteAwardById(awardId);
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating award record");
            }
        }
    }
}
