using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Infrastructure.EF.DbEntities;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Questions.Commands.Update;

public class QuestionUpdateHandler : GenericHandler<IQuestionRepository>, ICommandsHandler<QuestionUpdateCommand, bool>
{
    public QuestionUpdateHandler(IQuestionRepository tRepository) : base(tRepository)
    {
    }

    public bool Handle(QuestionUpdateCommand command)
    {
        var dbQuestion = _mapper.Map<DbQuestion>(command);
        return _TRepository.Update(dbQuestion);
    }
}