using MDT.Model.Data;
using MDT.UseCase.Goals;
using MDT.UseCase.Progress;
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
    public class ProgressController : ControllerBase
    {
        private readonly IProgressUseCase progressUseCase;
        
        public ProgressController(IProgressUseCase progressUseCase)
        {
            this.progressUseCase = progressUseCase;
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAllProgress()
        {
            var progress = new
            {
                progress = await progressUseCase.GetAllProgress()
            };

            return Ok(progress);
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetProgressById(int progressId)
        {
            try
            {
                if (progressId < 1)
                    return BadRequest();

                var progress = new
                {
                    progress = await progressUseCase.GetProgressById(progressId)
                };

                return Ok(progress);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving progress record");
            }
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAllProgressByGoalId(long goalId)
        {
            try
            {
                if (goalId < 1)
                    return BadRequest();

                var progress = new
                {
                    progress = await progressUseCase.GetAllProgressByGoal(goalId)
                };

                return Ok(progress);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving progress records by goalId");
            }
        }


        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAllProgressByUserId(string userId)
        {
            try
            {
                if (userId ==  null)
                    return BadRequest();

                var progress = new
                {
                    progress = await progressUseCase.GetAllProgressByUser(userId)
                };

                return Ok(progress);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving progress records by userId");
            }
        }


        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Progress>> CreateProgress([FromBody] Progress progress)
        {
            try
            {
                if (progress == null)
                    return BadRequest();

                var createdProgress = await progressUseCase.AddProgress(progress);

                return createdProgress;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new progress record");
            }
        }


        [HttpPut]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Progress>> UpdateProgress([FromBody] Progress progress)
        {
            try
            {
                if (progress == null || progress.Id < 1)
                    return BadRequest();

                var updatedProgress = await progressUseCase.UpdateProgress(progress);

                return updatedProgress;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating progress record");
            }
        }


        [HttpDelete]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteProgressById(int progressId)
        {
            try
            {
                if (progressId < 1)
                    return BadRequest();

                await progressUseCase.DeleteProgressById(progressId);
                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating progress record");
            }
        }
    }
}
