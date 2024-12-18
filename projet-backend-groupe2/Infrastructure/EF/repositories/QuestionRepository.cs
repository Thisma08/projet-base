using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Infrastructure.EF.repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuizzDbContext _context;

    public QuestionRepository(QuizzDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbQuestion> FetchAll()
    {
        return _context.Questions.ToList();
    }

    public DbQuestion? FetchById(int id)
    {
        return _context.Questions.FirstOrDefault(q => q.Id == id);
    }

    public DbQuestion Create(DbQuestion question)
    {
        _context.Questions.Add(question);
        _context.SaveChanges();
        return question;
    }

    public bool Update(DbQuestion question)
    {
        var entity = _context.Questions.FirstOrDefault(q => q.Id == question.Id);
        if (entity == null) return false;
        entity.QuestionText = question.QuestionText;
        entity.CorrectChoice = question.CorrectChoice;
        entity.IncorrectChoice1 = question.IncorrectChoice1;
        entity.IncorrectChoice2 = question.IncorrectChoice2;
        entity.IncorrectChoice3 = question.IncorrectChoice3;
        entity.QuizzId = question.QuizzId;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var question = _context.Questions.FirstOrDefault(q => q.Id == id);
        if (question == null) return false;
        _context.Questions.Remove(question);
        _context.SaveChanges();
        return true;
    }
}