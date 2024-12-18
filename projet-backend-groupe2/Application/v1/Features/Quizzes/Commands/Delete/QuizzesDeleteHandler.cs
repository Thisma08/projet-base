using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Quizzes.Commands.Delete;

public class QuizzesDeleteHandler :
    GenericHandler<IQuizzRepository>,
    ICommandsHandler<int, bool>
{
    public QuizzesDeleteHandler(IQuizzRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(int commands)
    {
        return _TRepository.Delete(commands);
    }
}