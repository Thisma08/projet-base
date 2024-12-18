using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF.interfaces;

public interface IUserRepository
{
    IEnumerable<DbUser> FetchAll();
    DbUser? FetchById(int id);
    DbUser Create(DbUser user);
    bool Update(DbUser user);
    bool Delete(int id);
    DbUser? FetchByName(string queryUsername);
}