using Application.v1.Shared.Token;
using Domain.utils;
using Domain.Utils;
using Infrastructure.EF.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProjetASP.Controllers.Shared;

public class Validation : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly IQuizzRepository? _quizzesRepository;

    public Validation(TokenService tokenService, IQuizzRepository? quizzesRepository)
    {
        _tokenService = tokenService;
        _quizzesRepository = quizzesRepository;
    }

    [NonAction]
    protected bool VerifyIfIsAdmin()
    {
        // Recovers the role the logged-in user
        Request.Cookies.TryGetValue("jwt_token", out var token);
        var roleJwt = _tokenService.GetRole(token);

        // Check if its connected
        if (roleJwt == null)
            return false;

        // Check if it's an admin
        return roleJwt.Equals(ListRoles.Admin.GetDescription());
    }

    [NonAction]
    protected bool ValidateUser(int id)
    {
        // Check if it's the user who creates a question for him or if the user is admin 
        Request.Cookies.TryGetValue("jwt_token", out var token);
        var roleJwt = _tokenService.GetRole(token);
        var idJwt = _tokenService.GetId(token);

        return roleJwt != null && idJwt != 0 && (roleJwt.Equals(ListRoles.Admin.GetDescription()) || idJwt == id);
    }

    [NonAction]
    protected bool ValidateUserWithQuizzId(int commandQuizzId)
    {
        if (_quizzesRepository == null)
            return false;

        var id = _quizzesRepository.FetchById(commandQuizzId)!.User.Id;
        return ValidateUser(id);
    }
}