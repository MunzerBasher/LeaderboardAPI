using LeaderboardAPI.Contracts;
using LeaderboardAPI.IServices;
using Microsoft.AspNetCore.Mvc;


namespace LeaderboardAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RacerController(IRacerServices racerServices) : ControllerBase
    {
        private readonly IRacerServices _racerServices = racerServices;

        [HttpPost("{RacerId}/Start")]

        public async Task<ActionResult<bool>> AddStartAsync(RacerStartRequest racerRequest)
        {
            if (racerRequest == null) return BadRequest();
            var result = await _racerServices.AddStarsAsync(racerRequest);
            return result ? Ok(result) : BadRequest();
        }

        [HttpPost("{RacerId}/Accolade")]

        public async Task<ActionResult<bool>> AddAccoladeAsync(RacerAccoladeRequest racerRequest)
        {
            if (racerRequest == null) return BadRequest();
            var result = await _racerServices.AddAccoladeAsync(racerRequest);
            return result ? Ok(result) : BadRequest();
        }

        [HttpPost("")]

        public async Task<ActionResult<bool>> AddAsync(RacerRequest racerRequest)
        {
            if (racerRequest == null) return BadRequest();
            var result = await _racerServices.AddAsync(racerRequest);
            return result ? Ok(result) : BadRequest();
        }

        [HttpDelete("{Id}")]


        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {
            if (Id < 0) return BadRequest();
            var result = await _racerServices.DeleteAsync(Id);
            return result ? NoContent() : BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, RacerRequest racer)
        {
            if (racer is null) return BadRequest();
            var result = await _racerServices.UpdateAsync(Id,racer);
            return result ? Ok(result) : NotFound("Racer is not found !");
        }

        

        [HttpGet("Search/{name}")]

        public async Task<ActionResult<IList<RacerResponseByDetails>>> SearchAsync(string name)
        {
            var result = await _racerServices.SearchAsync(name);
            return Ok(result);
        }

        [HttpGet("Details")]

        public async Task<ActionResult<IList<RacerResponse>>> GetAllByDetailsAsync()
        {
            var result = await _racerServices.GetAllByDetailsAsync();
            return Ok(result);
        }

        [HttpGet("Filter")]

        public async Task<ActionResult<IList<RacerResponse>>> FilterAllDetailsAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _racerServices.GetAllByDetailsAsync(startDate, endDate);
            return Ok(result);
        }


    }

}  