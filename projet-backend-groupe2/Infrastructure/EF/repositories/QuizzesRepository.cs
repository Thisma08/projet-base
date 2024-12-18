using Domain.exceptions;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.repositories;

public class QuizzesRepository : IQuizzRepository
{
    private readonly QuizzDbContext _context;

    public QuizzesRepository(QuizzDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbQuizz> FetchAll()
    {
        return _context.Quizzes
            .Include(q => q.Theme)
            .Include(q => q.User)
            .Include(q => q.Questions)
            .ToList();
    }

    public DbQuizz? FetchById(int id)
    {
        return _context.Quizzes
            .Include(q => q.Theme)
            .Include(q => q.User)
            .Include(q => q.Questions)
            .FirstOrDefault(q => q.Id == id);
    }

    public DbQuizz Create(DbQuizz quizzes)
    {
        if (quizzes.Theme.Id > 0)
        {
            var dbTheme = _context.Themes.Find(quizzes.Theme.Id);
            if (dbTheme == null)
                throw new NotFoundObjectException(quizzes.Theme.Id, "Theme");
            quizzes.Theme = dbTheme;
        }

        if (quizzes.User.Id > 0)
        {
            var dbUser = _context.Users.Find(quizzes.User.Id);
            if (dbUser == null)
                throw new NotFoundObjectException(quizzes.User.Id, "User");
            quizzes.User = dbUser;
        }

        foreach (var question in quizzes.Questions) _context.Questions.Add(question);

        _context.Quizzes.Add(quizzes);
        _context.SaveChanges();

        return quizzes;
    }

    public bool Update(DbQuizz quizz)
    {
        var quizzes = FetchById(quizz.Id);

        if (quizzes == null)
            return false;

        quizzes.Title = quizz.Title;
        quizzes.Description = quizz.Description;
        quizzes.ThemeId = quizz.ThemeId;

        _context.Quizzes.Update(quizzes);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var quizzes = _context.Quizzes
            .Include(q => q.Questions)
            .FirstOrDefault(q => q.Id == id);

        if (quizzes == null) return false;

        _context.Questions.RemoveRange(quizzes.Questions);
        _context.Quizzes.Remove(quizzes);
        _context.SaveChanges();

        return true;
    }
}