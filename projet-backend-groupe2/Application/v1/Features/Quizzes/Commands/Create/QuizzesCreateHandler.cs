using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Quizzes.Commands.Create;

public class QuizzesCreateHandler :
    GenericHandler<IQuizzRepository>,
    ICommandsHandler<QuizzesCreateCommand, QuizzesCreateOutput>
{
    public QuizzesCreateHandler(IQuizzRepository tRepository) : base(tRepository)
    {
    }

    public QuizzesCreateOutput Handle(QuizzesCreateCommand command)
    {
        var db = _mapper.Map<DbQuizz>(command);

        _TRepository.Create(db);

        return _mapper.Map<QuizzesCreateOutput>(db);
    }
}