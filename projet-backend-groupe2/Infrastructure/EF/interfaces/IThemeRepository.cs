using Infrastructure.EF.DbEntities;

namespace Infrastructure.EF.interfaces;

public interface IThemeRepository
{
    IEnumerable<DbTheme> FetchAll();
    DbTheme? FetchById(int id);
    DbTheme Create(DbTheme theme);
    bool Update(DbTheme theme);
    bool Delete(int id);
}