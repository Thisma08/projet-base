using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF.interfaces;

public interface IQuestionRepository
{
    IEnumerable<DbQuestion> FetchAll();
    DbQuestion? FetchById(int id);
    DbQuestion Create(DbQuestion question);
    bool Update(DbQuestion question);
    bool Delete(int id);
}