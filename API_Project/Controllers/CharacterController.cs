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
        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }
        //we can do that also
        //[HttpGet]
        //[Route("/getall")]
        [HttpGet("id")]
        public ActionResult<Character> GetSingle(int? id) {
        return Ok(_characterService.GetCharacterById(id));
        }


        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newcharacter) { 
        
            return Ok(_characterService.AddCharacter(newcharacter));   
        }
    }
}
