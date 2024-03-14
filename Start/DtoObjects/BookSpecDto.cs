
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Data.Context;

    public class BookSpecDto:BaseDto
    {
        public string name { get; set; }
        // [JsonIgnore]
        //public UserDto User { get; set; }
        //
        // public string Login { get => User.Login;} 
        // public string pas { get => User.pas;  }
         public Guid UserId { get; set; }

        public BookSpecDto()
        {
           // login =  User.Login;
        }

        public Expression<Func<BookDto, bool>> ByName()
        {
            return x => x.name == name;
        }
        public Expression<Func<BookDto, bool>> ByUserName(string UserName)
        {
            return x => x.User.Login == UserName;
        }
      
    }




