namespace DBAccessor;

public class UserFilter:IFilter
{
    public Guid? Id { get; set; }
    public string? Login { get; set; }
}