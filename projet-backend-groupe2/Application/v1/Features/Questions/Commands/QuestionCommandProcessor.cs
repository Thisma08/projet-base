using Application.v1.Features.Questions.Commands.Create;
using Application.v1.Features.Questions.Commands.Delete;
using Application.v1.Features.Questions.Commands.Update;

namespace Application.v1.Features.Questions.Commands;

public class QuestionCommandProcessor
{
    private readonly QuestionCreateHandler _createHandler;
    private readonly QuestionDeleteHandler _deleteHandler;
    private readonly QuestionUpdateHandler _updateHandler;

    public QuestionCommandProcessor(QuestionCreateHandler createHandler, QuestionUpdateHandler updateHandler,
        QuestionDeleteHandler deleteHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _deleteHandler = deleteHandler;
    }

    public QuestionCreateOutput Create(QuestionCreateCommand command)
    {
        return _createHandler.Handle(command);
    }

    public bool Update(QuestionUpdateCommand command)
    {
        return _updateHandler.Handle(command);
    }

    public bool Delete(int command)
    {
        return _deleteHandler.Handle(command);
    }
}