using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Scores.Queries.GetByQuizzId;

public class ScoreGetByQuizzIdHandler : GenericHandler<IScoreRepository>, IQueryHandler<int, ScoreGetByQuizzIdOutput>
{
    public ScoreGetByQuizzIdHandler(IScoreRepository tRepository) : base(tRepository)
    {
    }

    public ScoreGetByQuizzIdOutput Handle(int quizzId)
    {
        var output = new ScoreGetByQuizzIdOutput();

        var dbScores = _TRepository.FetchByQuizzId(quizzId);
        foreach (var dbScore in dbScores)
            output.Scores.Add(_mapper.Map<ScoreGetByQuizzIdOutput.Score>(dbScore));

        return output;
    }
}