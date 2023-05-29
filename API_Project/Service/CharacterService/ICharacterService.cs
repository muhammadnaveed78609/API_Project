namespace API_Project.Service.CharacterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int? id);
        List<Character> AddCharacter(Character newcharacter);
    }
}
