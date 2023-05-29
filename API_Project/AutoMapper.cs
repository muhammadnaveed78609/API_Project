using API_Project.Dtos.Character;
using AutoMapper;

namespace API_Project
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterdto, Character>();
        }
    }
}
