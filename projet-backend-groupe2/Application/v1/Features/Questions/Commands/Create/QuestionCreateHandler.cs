using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Questions.Commands.Create;

public class QuestionCreateHandler : GenericHandler<IQuestionRepository>,
    ICommandsHandler<QuestionCreateCommand, QuestionCreateOutput>
{
    public QuestionCreateHandler(IQuestionRepository tRepository) : base(tRepository)
    {
    }

    public QuestionCreateOutput Handle(QuestionCreateCommand command)
    {
        var dbQuestion = _mapper.Map<DbQuestion>(command);
        _TRepository.Create(dbQuestion);
        return _mapper.Map<QuestionCreateOutput>(dbQuestion);
    }
}