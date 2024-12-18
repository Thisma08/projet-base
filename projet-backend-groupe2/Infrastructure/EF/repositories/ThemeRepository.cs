using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Infrastructure.EF.repositories;

public class ThemeRepository : IThemeRepository
{
    private readonly QuizzDbContext _context;

    public ThemeRepository(QuizzDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbTheme> FetchAll()
    {
        return _context.Themes.ToList();
    }

    public DbTheme? FetchById(int id)
    {
        return _context.Themes.FirstOrDefault(t => t.Id == id);
    }

    public DbTheme Create(DbTheme theme)
    {
        _context.Themes.Add(theme);
        _context.SaveChanges();
        return theme;
    }

    public bool Update(DbTheme theme)
    {
        var entity = _context.Themes.FirstOrDefault(t => t.Id == theme.Id);
        if (entity == null) return false;
        entity.Title = theme.Title;
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var theme = _context.Themes.FirstOrDefault(t => t.Id == id);
        if (theme == null) return false;
        _context.Themes.Remove(theme);
        _context.SaveChanges();
        return true;
    }
}