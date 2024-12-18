using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Scores.Queries.GetAll;

public class ScoreGetAllHandler : GenericHandler<IScoreRepository>, IQueryHandlerEmptyQuery<ScoreGetAllOutput>
{
    public ScoreGetAllHandler(IScoreRepository tRepository) : base(tRepository)
    {
    }

    public ScoreGetAllOutput Handle()
    {
        var output = new ScoreGetAllOutput();

        foreach (var dbScore in _TRepository.FetchAll())
            output.Scores.Add(_mapper.Map<ScoreGetAllOutput.Score>(dbScore));

        return output;
    }
}