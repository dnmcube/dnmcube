using Data.Context;

namespace Start.Interfaces;

public interface IBaseRules
{
    Task<UserDto> GetUSerDto();
    Task<List<UserDto>>  GetUSerDtoList();
}