using Application.v1.Features.Questions.Commands;
using Application.v1.Features.Questions.Commands.Create;
using Application.v1.Features.Questions.Commands.Update;
using Application.v1.Shared.Token;
using Domain.utils;
using Domain.Utils;
using Infrastructure.EF;
using Infrastructure.EF.interfaces;
using Infrastructure.EF.repositories;
using Microsoft.AspNetCore.Mvc;
using ProjetASP.Controllers.Shared;

namespace ProjetASP.Controllers;

[ApiController]
[Route("/v1/questions")]
public class QuestionController : Validation
{
    private readonly QuestionCommandProcessor _commandProcessor;

    public QuestionController(QuestionCommandProcessor commandProcessor, TokenService tokenService,
        IQuizzRepository? quizzesRepository) : base(tokenService, quizzesRepository)
    {
        _commandProcessor = commandProcessor;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<QuestionCreateOutput> Create([FromBody] QuestionCreateCommand command)
    {
        if (ValidateUser(command.QuizzId) || VerifyIfIsAdmin())
            return _commandProcessor.Create(command);
        return new UnauthorizedResult();
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update([FromBody] QuestionUpdateCommand command)
    {
        if (ValidateUserWithQuizzId(command.QuizzId))
            return _commandProcessor.Update(command) ? new NoContentResult() : new NotFoundResult();
        return new UnauthorizedResult();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete([FromRoute] int id)
    {
        if (ValidateUser(id))
            return _commandProcessor.Delete(id) ? new NoContentResult() : new NotFoundResult();
        return new UnauthorizedResult();
    }
}