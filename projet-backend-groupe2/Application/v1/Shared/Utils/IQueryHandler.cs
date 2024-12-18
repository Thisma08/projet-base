namespace Application.v1.Shared.Utils;

public interface IQueryHandler<TQuery, TOutput>
{
    TOutput Handle(TQuery query);
}