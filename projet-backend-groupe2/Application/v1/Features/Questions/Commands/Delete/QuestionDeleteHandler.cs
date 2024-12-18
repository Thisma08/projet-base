using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Questions.Commands.Delete;

public class QuestionDeleteHandler : GenericHandler<IQuestionRepository>, ICommandsHandler<int, bool>
{
    public QuestionDeleteHandler(IQuestionRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(int command)
    {
        return _TRepository.Delete(command);
    }
}