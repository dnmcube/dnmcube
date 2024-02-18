using Autofac;
using AutoMapper;
using Data.Context;
using DtoObjects;
using DataBase;

namespace Accessors.mechanizm;

internal class CRUD<T> where T:BaseEntity
{
    protected Repo<T> _userRepo;
    protected readonly IMapper _mapper;


    public CRUD(Repo<T> userRepo , IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }
    public async Task Add(DtoObjectsAbstract context) 
    {
        var res = _mapper.Map<T>(context);
        await _userRepo.Add(res);
    }
}