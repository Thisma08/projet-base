using Application.v1.Features.Scores.Commands.Create;

namespace Application.v1.Features.Scores.Commands;

public class ScoreCommandProcessor
{
    private readonly ScoreCreateHandler _scoreCreateHandler;

    public ScoreCommandProcessor(ScoreCreateHandler scoreCreateHandler)
    {
        _scoreCreateHandler = scoreCreateHandler;
    }

    public ScoreCreateOutput Create(ScoreCreateCommand command)
    {
        return _scoreCreateHandler.Handle(command);
    }
}