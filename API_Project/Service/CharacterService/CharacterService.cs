using API_Project.Dtos.Character;
using API_Project.Models;
using AutoMapper;

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
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;   
        }
       


        public async Task<GenericServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter)
        {
            var serviceResponse = new GenericServiceResponse<List<GetCharacterDto>>();
            var charactr = _mapper.Map<Character>(newcharacter);
            charactr.Id=character.Max(c => c.Id)+1;
            character.Add(charactr);
            character.Add(_mapper.Map<Character>(newcharacter));
            serviceResponse.Data = character.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<GenericServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new GenericServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = character.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<GenericServiceResponse<GetCharacterDto>> GetCharacterById(int? id)
        {
            var serviceResponse = new GenericServiceResponse<GetCharacterDto>();
            var characters = character.FirstOrDefault(u=>u.Id==id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters);
            return serviceResponse;
        }

       public async Task<GenericServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterdto updatecharacter)
        {
            var serviceResponse = new GenericServiceResponse<GetCharacterDto>();
            try
            {
               
                var characters = character.FirstOrDefault(u => u.Id == updatecharacter.Id);
               if(characters is null)
                {
                    throw new Exception($"Character with Id '{updatecharacter.Id}' not fond ");
                }
               _mapper.Map(updatecharacter, characters);
                characters.Name = updatecharacter.Name;
                characters.Defense = updatecharacter.Defense;
                characters.Strength = updatecharacter.Strength;
                characters.Intelligent = updatecharacter.Intelligent;
                characters.Class = updatecharacter.Class;
                characters.Intelligent = updatecharacter.Intelligent;
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }




        
       public async Task<GenericServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new GenericServiceResponse<List<GetCharacterDto>>();
            try
            {
                var characters = character.FirstOrDefault(u => u.Id == id);
                if (characters is null)
                {
                    throw new Exception($"Character with Id '{id}' not fond ");
                }
                character.Remove(characters);
                serviceResponse.Data = character.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        Task<GenericServiceResponse<List<GetCharacterDto>>> ICharacterService.DeleteCharacter(int id)
        {
            throw new NotImplementedException();
        }
    }
    }

