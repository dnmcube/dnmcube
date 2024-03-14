

using System.Linq.Expressions;

namespace Data.Context;
public class UserDto:BaseDto
{
    public string Login { get; set; }
    public string? pas { get; set; }
    
    public Expression<Func<UserDto, bool>> ByLogin()
    {
        return  x => x.Login == Login;
    }



    public Expression<Func<UserDto, bool>>  TestNull()
    {
        return x => x.pas == pas;
    }
}

