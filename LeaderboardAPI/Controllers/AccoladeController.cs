using LeaderboardAPI.Date.Entites;
using LeaderboardAPI.Contracts;
using LeaderboardAPI.IServices;
using Microsoft.AspNetCore.Mvc;


namespace LeaderboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccoladeController(IAccoladeService accoladeService) : ControllerBase
    {
        private readonly IAccoladeService _accoladeService = accoladeService;





        [HttpPost]

        public async Task<ActionResult<bool>> AddAsync(AccoladeRequest AccoladeRequest)
        {
            if (AccoladeRequest == null) return BadRequest();
            var result = await _accoladeService.AddAsync(new Accolade { Name = AccoladeRequest .Name,Description = AccoladeRequest .Description});
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpDelete("{Id}")]


        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {
            if (Id < 0) return BadRequest();
            var result = await _accoladeService.DeleteAsync(Id);
            return result ? NoContent() : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAsync(Accolade AccoladeRequest)
        {
            if (AccoladeRequest is null) return BadRequest();
            var result = await _accoladeService.UpdateAsync(AccoladeRequest);
            return result ? Ok(result) : NotFound("Racer is not found !");
        }
        [HttpGet]

        public async Task<ActionResult<IList<Racer>>> GetAllAsync()
        {
            var result = await _accoladeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Racer>> GetAsync(int Id)
        {
            var result = await _accoladeService.GetAsync(Id);
            return result is null ? Ok(result) : NotFound("Racer is not found !");
        }


    }





}