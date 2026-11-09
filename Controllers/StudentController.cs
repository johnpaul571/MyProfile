using Microsoft.AspNetCore.Mvc;
using MyProfileWeb.Models;

namespace MyProfileWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
[IgnoreAntiforgeryToken]
public class StudentController : ControllerBase
{
    /// <summary>
    /// Retrieves student profile details.
    /// </summary>
    /// <returns>Student information object</returns>
    [HttpGet]
    [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
    public ActionResult<Student> GetStudentInfo()
    {
        var student = new Student
        {
            Name = "John Paul C. Ayupan",
            Age = 23,
            Course = "BSIT",
            YearLevel = "3rd year college",
            School = "Southern Christian College",
            Location = "Poblacion III, Pigcawayan, North Cotabato",
            ContactNumber = "09776727018",
            Birthday = "June 15, 2003",
            FavoriteSport = "Basketball"
        };

        return Ok(student);
    }
}