using API_Project.Dtos.Character;

namespace API_Project.Service.CharacterService
{
    public interface ICharacterService
    {
        Task<GenericServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<GenericServiceResponse<GetCharacterDto>> GetCharacterById(int? id);
        Task<GenericServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter);
        Task<GenericServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterdto newcharacter);
        Task<GenericServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id );
    }
}
