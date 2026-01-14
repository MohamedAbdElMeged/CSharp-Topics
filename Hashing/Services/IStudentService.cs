using Hashing.Dtos;
using Hashing.Models;

namespace Hashing.Services;

public interface IStudentService
{
    public Task<Student> CreateAsync(CreateStudentRequest createStudentRequest);
    public Task<Student> Search(string userNameInput);

}