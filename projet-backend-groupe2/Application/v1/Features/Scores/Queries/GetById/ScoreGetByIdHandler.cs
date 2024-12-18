using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Domain.exceptions;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Scores.Queries.GetById;

public class ScoreGetByIdHandler : GenericHandler<IScoreRepository>, IQueryHandler<int, ScoreGetByIdOutput>
{
    public ScoreGetByIdHandler(IScoreRepository tRepository) : base(tRepository)
    {
    }

    public ScoreGetByIdOutput Handle(int quizzId)
    {
        var dbScore = _TRepository.FetchById(quizzId);
        if (dbScore == null)
            throw new NotFoundObjectException(quizzId, "Score");

        return _mapper.Map<ScoreGetByIdOutput>(dbScore);
    }
}