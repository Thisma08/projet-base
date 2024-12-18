using Application.v1.Cores.Users.Commands;
using Application.v1.Cores.Users.Commands.Create;
using Application.v1.Cores.Users.Commands.Login;
using Application.v1.Cores.Users.Commands.Update;
using Application.v1.Cores.Users.Query;
using Application.v1.Shared.Token;
using Domain.utils;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ProjetASP.Controllers;

[ApiController]
[Route("/v1/users")]
public class UsersController : ControllerBase
{
    private readonly UsersCommandsProcessors _commandProcessor;
    private readonly UsersQueryProcessors _queryProcessors;
    private readonly TokenService _tokenService;

    public UsersController(UsersCommandsProcessors commandProcessor, UsersQueryProcessors queryProcessors,
        TokenService tokenService)
    {
        _commandProcessor = commandProcessor;
        _queryProcessors = queryProcessors;
        _tokenService = tokenService;
    }
    
    [HttpGet("role")]
    public IActionResult GetRole()
    {
        Request.Cookies.TryGetValue("jwt_token", out var token);

        if (token == null || !_tokenService.IsTokenValid(token))
        {
            return Unauthorized("Invalid token");
        }

        var role = _tokenService.GetRole(token);
        return Ok(new { role });
    }

    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<UsersLoginOutput> Logout()
    {
        Response.Cookies.Delete("jwt_token");
        return Ok();
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<UsersLoginOutput> Login([FromBody] UsersLoginCommand command)
    {
        var output = _commandProcessor.Login(command);

        var token = _tokenService.BuildToken(output);

        Response.Cookies.Append("jwt_token", token,
            new CookieOptions
            {
                Secure = true, HttpOnly = true, Path = "/",
                Expires = DateTime.UtcNow.AddMinutes(TokenService.ExpiryDurationMinutes)
            });

        return Ok(output);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult Create([FromBody] UsersCreateCommand command)
    {
        Request.Cookies.TryGetValue("jwt_token", out var token);

        // Check if it's an existing role
        if (!command.Role.Equals(ListRoles.Admin.GetDescription()) &&
            !command.Role.Equals(ListRoles.User.GetDescription()))
            command.Role = ListRoles.User.GetDescription();

        // Check if it's an admin creating a role other than user
        if (command.Role.Equals(ListRoles.Admin.GetDescription()) &&
            (token == null || !_tokenService.GetRole(token)!.Equals(ListRoles.Admin.GetDescription())))
            return new UnauthorizedResult();

        return Ok(_commandProcessor.Create(command));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete([FromRoute] int id)
    {
        Request.Cookies.TryGetValue("jwt_token", out var token);

        // Check if he is an admin or if he wants to delete himself
        if (id == _tokenService.GetId(token) || _tokenService.GetRole(token)!.Equals(ListRoles.Admin.GetDescription()))
        {
            // If you delete your account, you log out at the same time
            if (id == _tokenService.GetId(token))
                Logout();
            return _commandProcessor.Delete(id) ? new NoContentResult() : new NotFoundResult();
        }

        return new UnauthorizedResult();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update([FromBody] UsersUpdateCommand command)
    {
        // Recovers the role and id of the logged-in user
        Request.Cookies.TryGetValue("jwt_token", out var token);
        var roleJwt = _tokenService.GetRole(token);
        var idJwt = _tokenService.GetId(token);

        // Check if it's an existing role
        if (!command.Role.Equals(ListRoles.Admin.GetDescription()) ||
            !command.Role.Equals(ListRoles.User.GetDescription()))
            command.Role = ListRoles.User.GetDescription();

        // Check if it's an admin creating a role other than user
        if (command.Role.Equals(ListRoles.Admin.GetDescription())
            && roleJwt == null && !roleJwt!.Equals(ListRoles.Admin.GetDescription()))
            return new UnauthorizedResult();

        // Check if it's an admin or himself who modifies his profile
        if (roleJwt == null || idJwt == 0 ||
            (!roleJwt!.Equals(ListRoles.Admin.GetDescription()) && idJwt != command.Id))
            return new UnauthorizedResult();

        return _commandProcessor.Update(command) ? new NoContentResult() : new NotFoundResult();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IResult GetById([FromRoute] int id)
    {
        var users = _queryProcessors.GetById(id);
        return Results.Ok(users);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult GetAll()
    {
        var users = _queryProcessors.GetAll();
        return Results.Ok(users);
    }
}