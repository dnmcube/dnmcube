using AutoMapper;
using Data.Context;

namespace Accessors.Profiles;

internal class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, UserDto>().ReverseMap();
        
       // CreateMap<MyDto, User>().ReverseMap();
    }
}