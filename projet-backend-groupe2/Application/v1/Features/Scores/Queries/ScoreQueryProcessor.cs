using Application.v1.Features.Scores.Queries.GetAll;
using Application.v1.Features.Scores.Queries.GetById;
using Application.v1.Features.Scores.Queries.GetByQuizzId;
using Application.v1.Features.Scores.Queries.GetByUserId;

namespace Application.v1.Features.Scores.Queries;

public class ScoreQueryProcessor
{
    private readonly ScoreGetAllHandler _getAllHandler;
    private readonly ScoreGetByIdHandler _getByIdHandler;
    private readonly ScoreGetByQuizzIdHandler _getByQuizzIdHandler;
    private readonly ScoreGetByUserIdHandler _getByUserIdHandler;


    public ScoreQueryProcessor(ScoreGetAllHandler getAllHandler, ScoreGetByIdHandler getByIdHandler,
        ScoreGetByUserIdHandler getByUserIdHandler, ScoreGetByQuizzIdHandler getByQuizzIdHandler)
    {
        _getAllHandler = getAllHandler;
        _getByIdHandler = getByIdHandler;
        _getByUserIdHandler = getByUserIdHandler;
        _getByQuizzIdHandler = getByQuizzIdHandler;
    }

    public List<ScoreGetAllOutput.Score> GetAll()
    {
        return _getAllHandler.Handle().Scores;
    }

    public ScoreGetByIdOutput GetById(int id)
    {
        return _getByIdHandler.Handle(id);
    }

    public List<ScoreGetByUserIdOutput.Score> GetByUserId(int userId)
    {
        var output = _getByUserIdHandler.Handle(userId);
        return output.Scores;
    }

    public List<ScoreGetByQuizzIdOutput.Score> GetByQuizzId(int quizzId)
    {
        var output = _getByQuizzIdHandler.Handle(quizzId);
        return output.Scores;
    }
}