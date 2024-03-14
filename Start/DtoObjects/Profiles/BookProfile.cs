using AutoMapper;
using Data.Context;

namespace Accessors.Profiles;

internal class BookProfile:Profile
{
    public BookProfile()
    {
        CreateMap<BookDto, BookDto>().ReverseMap(); 
        CreateMap<BookSpecDto, BookDto>().ReverseMap(); 
    }
}