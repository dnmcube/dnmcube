using System.Linq.Expressions;
using Data.Context;
using Data;

namespace DataBase;

internal class Repo<T>  where T: BaseEntity
{
    private  DbDataBase _context { get; }
    public Repo(DbDataBase context)
    {
        _context = context;
    }

    public IQueryable<T> GetQueryable(Expression<Func<T,bool>> query)
    {
     
        
        return _context.Set<T>().Where(query);
    }
    public IQueryable<T> GetQueryable()
    {
        return _context.Set<T>();
    }

    public async Task Add(T user)
    {
         _context.Add(user);
         await _context.SaveChangesAsync();
    }
}