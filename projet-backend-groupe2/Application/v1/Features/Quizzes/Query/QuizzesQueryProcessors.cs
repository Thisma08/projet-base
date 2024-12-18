using Application.v1.Features.Quizzes.Query.GetAll;
using Application.v1.Features.Quizzes.Query.GetById;

namespace Application.v1.Features.Quizzes.Query;

public class QuizzesQueryProcessors
{
    private readonly QuizzesGetAllHandler _GetAllHandler;
    private readonly QuizzesGetByIdHandler _getByIdHandler;

    public QuizzesQueryProcessors(QuizzesGetAllHandler getAllHandler, QuizzesGetByIdHandler getByIdHandler)
    {
        _GetAllHandler = getAllHandler;
        _getByIdHandler = getByIdHandler;
    }

    public QuizzesGetAllOutput GetAll()
    {
        return _GetAllHandler.Handle();
    }

    public QuizzesGetByIdOutput GetById(int id)
    {
        return _getByIdHandler.Handle(id);
    }
}