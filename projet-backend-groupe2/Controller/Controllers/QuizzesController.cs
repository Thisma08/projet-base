using Application.v1.Features.Quizzes.Commands;
using Application.v1.Features.Quizzes.Commands.Create;
using Application.v1.Features.Quizzes.Commands.Update;
using Application.v1.Features.Quizzes.Query;
using Microsoft.AspNetCore.Mvc;

namespace ProjetASP.Controllers;

[ApiController]
[Route("/v1/quizzes")]
public class QuizzesController : ControllerBase
{
    private readonly QuizzesCommandsProcessors _commandProcessor;
    private readonly QuizzesQueryProcessors _queryProcessors;
    
    public QuizzesController(QuizzesCommandsProcessors commandProcessor, QuizzesQueryProcessors queryProcessors)
    {
        _commandProcessor = commandProcessor;
        _queryProcessors = queryProcessors;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<QuizzesCreateOutput> Create([FromBody] QuizzesCreateCommand command)
    {
        return _commandProcessor.Create(command);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete([FromRoute] int id)
    {
        return _commandProcessor.Delete(id) ? new NoContentResult() : new NotFoundResult();
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update([FromBody] QuizzesUpdateCommand command)
    {
        return _commandProcessor.Update(command) ? new NoContentResult() : new NotFoundResult();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult GetById([FromRoute] int id)
    {
        var quizzes = _queryProcessors.GetById(id);
        return Results.Ok(quizzes);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult GetAll()
    {
        var quizzes = _queryProcessors.GetAll().ListQuizzes;
        return Results.Ok(quizzes);
    }
}