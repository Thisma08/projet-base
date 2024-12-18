using Application.v1.Features.Scores.Commands;
using Application.v1.Features.Scores.Commands.Create;
using Application.v1.Features.Scores.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ProjetASP.Controllers;

[ApiController]
[Route("/v1/scores")]
public class ScoreController : ControllerBase
{
    // TODO : a reviser, car je comprend pas la logique
    
    private readonly ScoreCommandProcessor _commandProcessor;
    private readonly ScoreQueryProcessor _queryProcessor;
    
    public ScoreController(ScoreCommandProcessor commandProcessor, ScoreQueryProcessor queryProcessor)
    {
        _commandProcessor = commandProcessor;
        _queryProcessor = queryProcessor;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult GetAll()
    {
        var scores = _queryProcessor.GetAll();
        return Results.Ok(scores);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult GetById([FromRoute] int id)
    {
        var scores = _queryProcessor.GetById(id);
        return Results.Ok(scores);
    }
    
    [HttpGet("joueur/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult GetByUserId(int id)
    {
        var scores = _queryProcessor.GetByUserId(id);
        if (scores.Count == 0)
            return Results.NotFound($"No scores found for user ID {id}");
    
        return Results.Ok(scores);
    }
    
    [HttpGet("quizz/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult GetByQuizzId(int id)
    {
        var scores = _queryProcessor.GetByQuizzId(id);
        if (scores.Count == 0)
            return Results.NotFound($"No scores found for quizz ID {id}");
    
        return Results.Ok(scores);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<ScoreCreateOutput> Create([FromBody] ScoreCreateCommand command)
    {
        return _commandProcessor.Create(command);
    }
}