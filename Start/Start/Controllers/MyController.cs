using DBAccessor;
using DtoObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Start.Controllers;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
    private readonly IBaseAccessor _baseAccessor;
    public MyController( IBaseAccessor baseAccessor)
    {
        _baseAccessor = baseAccessor;
    }

    [HttpGet("Test")]
    public async Task<IActionResult> Get()
    {
        var first = await _baseAccessor.userAccessor.GiveMeDtoFirstOrDefault<UserDto>(
            new UserFilter() { Id = new Guid("a5dbdbd0-5d4e-43ec-8df4-3e16ebc126a2") }
        );
      //   UserDto first = new UserDto();
      // first.Login = "password";
      // await _baseAccessor.userAccessor.Add(first);
      
      // BookDto BookDto = new BookDto();
      // BookDto.name = "voinaimir";
      // BookDto.UserId = first.Id;
      // await _baseAccessor.bookAccessor.Add(BookDto);

    var list = await _baseAccessor.bookAccessor.GiveMeDtoToList<BookDto>(new UserFilter());
    return Ok(list);
    }
}