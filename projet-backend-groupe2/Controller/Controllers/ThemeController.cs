using Application.v1.Cores.Themes.Commands;
using Application.v1.Cores.Themes.Commands.Create;
using Application.v1.Cores.Themes.Commands.Update;
using Application.v1.Cores.Themes.Queries;
using Application.v1.Shared.Token;
using Microsoft.AspNetCore.Mvc;

namespace ProjetASP.Controllers;

[ApiController]
[Route("/v1/themes")]
public class ThemeController : Shared.Validation
{
    private readonly ThemeCommandProcessor _commandProcessor;
    private readonly ThemeQueryProcessor _queryProcessor;


    public ThemeController(ThemeCommandProcessor commandProcessor, ThemeQueryProcessor queryProcessor,
        TokenService tokenService) : base(tokenService, null)
    {
        _commandProcessor = commandProcessor;
        _queryProcessor = queryProcessor;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult GetAll()
    {
        var themes = _queryProcessor.GetAll();
        return Results.Ok(themes);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<ThemeCreateOutput> Create([FromBody] ThemeCreateCommand command)
    {
        if (VerifyIfIsAdmin())
            return _commandProcessor.Create(command);
        return new UnauthorizedResult();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update([FromBody] ThemeUpdateCommand command)
    {
        if (VerifyIfIsAdmin())
            return _commandProcessor.Update(command) ? new NoContentResult() : new NotFoundResult();
        return new UnauthorizedResult();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete([FromRoute] int id)
    {
        if (VerifyIfIsAdmin())
            return _commandProcessor.Delete(id) ? new NoContentResult() : new NotFoundResult();
        return new UnauthorizedResult();
    }
}