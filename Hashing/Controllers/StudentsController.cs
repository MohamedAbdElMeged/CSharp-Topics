using Hashing.Dtos;
using Hashing.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hashing.Controllers;

[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateStudentRequest createStudentRequest)
    {
        var student = await _studentService.CreateAsync(createStudentRequest);
        var hash = new
        {
            Id = student.Id,
            userName = student.UserName,
            userNameHashed= student.UserNameHashed
        };
        return Ok(hash);
    }

    [HttpGet("Search")]
    public async Task<IActionResult> Search([FromQuery] string userNameInput)
    {
        var student = await _studentService.Search(userNameInput);
        var hash = new
        {
            Id = student.Id,
            userName = student.UserName,
            userNameHashed= student.UserNameHashed
        };
        return Ok(hash);
    }
    
    
    
}