
using System.Linq.Expressions;

namespace Data.Context;

    public class BookDto:BaseDto
    {
        public string name { get; set; }
        public UserDto User { get; set; }
        public Guid UserId { get; set; }


        public Expression<Func<BookDto, bool>> ByName()
        {
            return x => x.name == name;
        }
        
        public Expression<Func<BookDto, bool>> UserByPas(string pas)
        {
            return x => x.User.pas == pas;
        }
    }




