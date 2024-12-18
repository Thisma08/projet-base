using Application.v1.Features.Quizzes.Commands.Create;
using Application.v1.Features.Quizzes.Commands.Delete;
using Application.v1.Features.Quizzes.Commands.Update;

namespace Application.v1.Features.Quizzes.Commands;

public class QuizzesCommandsProcessors
{
    private readonly QuizzesCreateHandler _createHandler;
    private readonly QuizzesDeleteHandler _deleteHandler;
    private readonly QuizzesUpdateHandler _updateHandler;

    public QuizzesCommandsProcessors(QuizzesCreateHandler createHandler, QuizzesDeleteHandler deleteHandler,
        QuizzesUpdateHandler updateHandler)
    {
        _createHandler = createHandler;
        _deleteHandler = deleteHandler;
        _updateHandler = updateHandler;
    }

    public QuizzesCreateOutput Create(QuizzesCreateCommand command)
    {
        return _createHandler.Handle(command);
    }

    public bool Delete(int query)
    {
        return _deleteHandler.Handle(query);
    }

    public bool Update(QuizzesUpdateCommand command)
    {
        return _updateHandler.Handle(command);
    }
}