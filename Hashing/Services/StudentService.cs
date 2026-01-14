using Hashing.Data;
using Hashing.Dtos;
using Hashing.Models;
using Hashing.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Hashing.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;
    private readonly IPiiProtector _piiProtector;

    public StudentService(AppDbContext context, IPiiProtector piiProtector )
    {
        _context = context;
        _piiProtector = piiProtector;
    }
    public async Task<Student> CreateAsync(CreateStudentRequest createStudentRequest)
    {
        var userNameEncrypted = _piiProtector.Protect(createStudentRequest.UserName);
        var userNameHashed = _piiProtector.HashForLookup(createStudentRequest.UserName);

        var student = new Student()
        {
            UserName = userNameEncrypted,
            UserNameHashed = userNameHashed
        };
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> Search(string userNameInput)
    {
        var userNameInputHashed = _piiProtector.HashForLookup(userNameInput);
        return await _context.Students.FirstOrDefaultAsync(s => s.UserNameHashed == userNameInputHashed);
    }
}