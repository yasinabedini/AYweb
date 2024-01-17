using AIPFramework.Queries;
using AYweb.Application.Models.User.Commands.CreateUser;
using AYweb.Application.Models.User.Queries.GetAllUserQuery;
using AYweb.Application.Models.User.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ayweb.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sernder;


    public UserController(ISender sernder)
    {
        _sernder = sernder;
    }

    [HttpPost]
    public IActionResult Create(CreateUserCommand user)
    {
        _sernder.Send(user);
        return Ok(true);
    }

    [HttpGet("/user/getAll")]
    public IActionResult GetAll(int pagenumber = 1)
    {
        var res = _sernder.Send(new GetAllUserQuery() { PageNumber = pagenumber });
        return Ok(res.Result);
    }

    [HttpGet("/User/GetUserById/{id}")]
    public IActionResult GetById(int id)
    {
        var res = _sernder.Send(new GetUserQuery() { Id = id });
        return Ok(res.Result);

    }
}
