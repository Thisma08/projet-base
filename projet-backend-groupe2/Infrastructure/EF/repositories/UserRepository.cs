using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Infrastructure.EF.repositories;

public class UserRepository : IUserRepository
{
    private readonly QuizzDbContext _context;

    public UserRepository(QuizzDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbUser> FetchAll()
    {
        return _context.Users.ToList();
    }

    public DbUser? FetchById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public DbUser Create(DbUser user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public bool Update(DbUser user)
    {
        var entity = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (entity == null) return false;
        entity.Username = user.Username;
        entity.Email = user.Email;
        entity.Password = user.Password;
        entity.Role = user.Role;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return false;
        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }

    public DbUser? FetchByName(string queryUsername)
    {
        return _context.Users.FirstOrDefault(u => u.Username == queryUsername);
    }
}