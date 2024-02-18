using AutoMapper;
using Data.Context;
using DtoObjects;

namespace Accessors.Profiles;

internal class BookProfile:Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
       
    }
}