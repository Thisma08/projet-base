using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Scores.Commands.Create;

public class ScoreCreateHandler : GenericHandler<IScoreRepository>,
    ICommandsHandler<ScoreCreateCommand, ScoreCreateOutput>
{
    public ScoreCreateHandler(IScoreRepository tRepository) : base(tRepository)
    {
    }

    public ScoreCreateOutput Handle(ScoreCreateCommand command)
    {
        var dbScore = _mapper.Map<DbScore>(command);
        Console.WriteLine(dbScore.ScoreValue);
        _TRepository.Create(dbScore);
        return _mapper.Map<ScoreCreateOutput>(dbScore);
    }
}