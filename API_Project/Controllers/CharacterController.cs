using API_Project.Dtos.Character;
using API_Project.Models;
using API_Project.Service.CharacterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
       
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(knight);
        //}
        [HttpGet("getall")]
        public async Task<ActionResult<GenericServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        //we can do that also
        //[HttpGet]
        //[Route("/getall")]
        [HttpGet("id")]
        public async Task<ActionResult<GenericServiceResponse<GetCharacterDto>>> GetSingle(int? id) {
        return Ok(await _characterService.GetCharacterById(id));
        }


        [HttpPost]
        public async Task<ActionResult<GenericServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newcharacter) { 
        
            return Ok(await _characterService.AddCharacter(newcharacter)); 
        }

        [HttpPut]
        public async Task<ActionResult<GenericServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterdto updatecharacter)
        {
            var response = await _characterService.UpdateCharacter(updatecharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericServiceResponse<List<GetCharacterDto>>>> DeleteCharacter( int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
