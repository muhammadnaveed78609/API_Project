using API_Project.Models;

namespace API_Project.Service.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> character = new List<Character>
        {
            new Character(),
            new Character
            {
                Name="M. Naveed"
            }
        };
        public List<Character> AddCharacter(Character newcharacter)
        {
           character.Add(newcharacter);
            return character;
        }

        public List<Character> GetAllCharacters()
        {
            return character;
        }

        public Character GetCharacterById(int? id)
        {
           var characters= character.FirstOrDefault(c => c.Id == id);
            if(character is not null)
            {
                return characters;
            }
            throw new Exception("Character not found");
        }
    }
}
