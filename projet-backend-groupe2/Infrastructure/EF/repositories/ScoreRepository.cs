using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Infrastructure.EF.repositories;

public class ScoreRepository : IScoreRepository
{
    private readonly QuizzDbContext _context;

    public ScoreRepository(QuizzDbContext context)
    {
        _context = context;
    }

    public IEnumerable<DbScore> FetchAll()
    {
        return _context.Scores.ToList();
    }

    public DbScore? FetchById(int id)
    {
        return _context.Scores.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<DbScore> FetchByUserId(int userId)
    {
        return _context.Scores.Where(s => s.UserId == userId).ToList();
    }

    public IEnumerable<DbScore> FetchByQuizzId(int quizzId)
    {
        return _context.Scores.Where(s => s.QuizzId == quizzId).ToList();
    }

    public DbScore Create(DbScore score)
    {
        _context.Scores.Add(score);
        _context.SaveChanges();
        return score;
    }

    public bool Update(DbScore score)
    {
        var entity = _context.Scores.FirstOrDefault(s => s.Id == score.Id);
        if (entity == null) return false;
        entity.ScoreValue = score.ScoreValue;
        entity.UserId = score.UserId;
        entity.QuizzId = score.QuizzId;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var score = _context.Scores.FirstOrDefault(s => s.Id == id);
        if (score == null) return false;
        _context.Scores.Remove(score);
        _context.SaveChanges();
        return true;
    }
}