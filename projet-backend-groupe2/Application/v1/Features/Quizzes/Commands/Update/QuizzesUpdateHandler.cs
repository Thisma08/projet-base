using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Quizzes.Commands.Update;

public class QuizzesUpdateHandler :
    GenericHandler<IQuizzRepository>,
    ICommandsHandler<QuizzesUpdateCommand, bool>
{
    public QuizzesUpdateHandler(IQuizzRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(QuizzesUpdateCommand command)
    {
        var db = _mapper.Map<QuizzesUpdateCommand, DbQuizz>(command);
        return _TRepository.Update(db);
    }
}