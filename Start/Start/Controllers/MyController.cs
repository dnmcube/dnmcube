using Accessors.mechanizm;
using Autofac;
using AutoMapper;
using Calculator;
using Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Start.Controllers;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{
   // private readonly IBaseRules _baseRules;
    private readonly ILifetimeScope _lifetimeScope;
    private readonly IAccessor _baseAccessor;
    private readonly IMapper mapper;
    public MyController( ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
        _baseAccessor = _lifetimeScope.Resolve<IAccessor>();
    }

    [HttpGet("Test")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var userFilter = new UserDto();
            userFilter.Login = "asd";

            var bookFilter = new BookSpecDto();
            bookFilter.name = "qweqweqasdasd";
            bookFilter.UserId =new  Guid("a3dbdbd0-5d4e-43ec-8df4-3e16ebc126a3");
            
            
          //  mapper.Map<BookSpecDto>(bookFilter);

          //  var res = await _baseAccessor.FirstOrDefault(bookFilter.ByName());
          //  var res = await _baseAccessor.ToList<BookSpecDto, BookDto>(bookFilter.ByName());
            await _baseAccessor.Add<BookSpecDto, BookDto>(bookFilter);
            // var res1 = await _baseAccessor.ToList(bookFilter.ByName());
        
            // if (res != null)
            // {
            return Ok();
            // }
            // else
            // {
            //     return StatusCode(StatusCodes.Status404NotFound, "null");
            // }
        }
        catch (Exception ex)
        {
            return Ok(ex);
        }
        
    }
    
    [HttpGet("Decorator")]
    public  IActionResult Decorator()
    {
        var command = new PlusCommand(10, 4);
        var invoker = new CalcInvoker();
        invoker.SetCommand(command);
       
        return Ok( invoker.execute());
    }
}