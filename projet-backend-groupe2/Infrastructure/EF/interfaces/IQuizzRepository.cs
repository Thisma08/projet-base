using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF.interfaces;

public interface IQuizzRepository
{
    IEnumerable<DbQuizz> FetchAll();
    DbQuizz? FetchById(int id);
    DbQuizz Create(DbQuizz quizzes);
    bool Update(DbQuizz quizz);
    bool Delete(int id);
}