using Start.Interfaces;

namespace Rules;

// public class BaseRules:IBaseRules
// {
//     private readonly IBaseAccessor _baseAccessor;
//     public BaseRules(IBaseAccessor baseAccessor)
//     {
//         _baseAccessor = baseAccessor;
//     }
//
//
//     public  Task<List<UserDto>> GetUSerDtoList()
//     {
//         var userFilter = new UserFilter();
//         userFilter.LoginAndId();
//         var res = _baseAccessor.userAccessor.GiveMeDtoToList<UserDto>(userFilter);
//         return res;
//     } 
//     
//     
//     public  Task<UserDto> GetUSerDto()
//     {
//         var userFilter = new UserFilter();
//         userFilter.LoginAndId();
//         var result =  _baseAccessor.userAccessor.GiveMeDtoFirstOrDefault<UserDto>(userFilter);
//         return result;
//     } 
// }