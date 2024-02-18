using AutoMapper;
using Data.Context;
using DtoObjects;

namespace Accessors.Profiles;

internal class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<MyDto, User>().ReverseMap();
    }
}