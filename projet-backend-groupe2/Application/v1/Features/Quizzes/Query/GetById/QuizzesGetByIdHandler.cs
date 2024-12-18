using Application.v1.Shared.Generic;
using Application.v1.Shared.Utils;
using Domain.exceptions;
using Infrastructure.EF.interfaces;

namespace Application.v1.Features.Quizzes.Query.GetById;

public class QuizzesGetByIdHandler :
    GenericHandler<IQuizzRepository>,
    IQueryHandler<int, QuizzesGetByIdOutput>
{
    public QuizzesGetByIdHandler(IQuizzRepository tRepository) : base(tRepository)
    {
    }

    public QuizzesGetByIdOutput Handle(int quizzId)
    {
        var db = _TRepository.FetchById(quizzId);
        if (_TRepository.FetchById(quizzId) == null)
            throw new NotFoundObjectException(quizzId, "User");


        return _mapper.Map<QuizzesGetByIdOutput>(db);
    }
}