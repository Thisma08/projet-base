using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF.interfaces;

public interface IScoreRepository
{
    IEnumerable<DbScore> FetchAll();
    DbScore? FetchById(int id);
    IEnumerable<DbScore> FetchByUserId(int userId);
    public IEnumerable<DbScore> FetchByQuizzId(int quizzId);
    DbScore Create(DbScore score);
    bool Update(DbScore score);
    bool Delete(int id);
}