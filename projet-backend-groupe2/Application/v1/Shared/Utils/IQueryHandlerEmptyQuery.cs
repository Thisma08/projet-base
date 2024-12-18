namespace Application.v1.Shared.Utils;

public interface IQueryHandlerEmptyQuery<TOutput>
{
    TOutput Handle();
}