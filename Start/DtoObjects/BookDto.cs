namespace DtoObjects;

public class BookDto:DtoObjectsAbstract
{
    public string Name { get; set; }
    public Guid UserId { get; set; }
    public UserDto User { get; set; }
}