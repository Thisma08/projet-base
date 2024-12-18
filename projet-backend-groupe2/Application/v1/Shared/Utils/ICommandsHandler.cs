namespace Application.v1.Shared.Utils;

public interface ICommandsHandler<TQuery, TOutput>
    // where TQuery : class
    // where TOutput : class
{
    TOutput Handle(TQuery query);
}