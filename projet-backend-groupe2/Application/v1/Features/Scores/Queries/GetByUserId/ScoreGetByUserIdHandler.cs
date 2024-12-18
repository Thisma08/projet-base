using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Scores.Queries.GetByUserId;

public class ScoreGetByUserIdHandler : GenericHandler<IScoreRepository>, IQueryHandler<int, ScoreGetByUserIdOutput>
{
    public ScoreGetByUserIdHandler(IScoreRepository tRepository) : base(tRepository)
    {
    }

    public ScoreGetByUserIdOutput Handle(int quizzId)
    {
        var output = new ScoreGetByUserIdOutput();

        var dbScores = _TRepository.FetchByUserId(quizzId);
        foreach (var dbScore in dbScores)
            output.Scores.Add(_mapper.Map<ScoreGetByUserIdOutput.Score>(dbScore));

        return output;
    }
}