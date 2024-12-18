using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Quizzes.Query.GetAll;

public class QuizzesGetAllHandler :
    GenericHandler<IQuizzRepository>,
    IQueryHandlerEmptyQuery<QuizzesGetAllOutput>
{
    public QuizzesGetAllHandler(IQuizzRepository tRepository) : base(tRepository)
    {
    }

    public QuizzesGetAllOutput Handle()
    {
        var output = new QuizzesGetAllOutput();
        foreach (var db in _TRepository.FetchAll())
            output.ListQuizzes.Add(_mapper.Map<QuizzesGetAllOutput.Quizz>(db));

        return output;
    }
}