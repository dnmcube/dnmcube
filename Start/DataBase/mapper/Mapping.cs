using AutoMapper;
using Accessors.Profiles;
namespace mapper;

public class Mapping
{
    public IMapper Configurate => new MapperConfiguration(cfg =>
    {
       cfg.AddProfile(new UserProfile());
       cfg.AddProfile(new BookProfile());
    }).CreateMapper();

}