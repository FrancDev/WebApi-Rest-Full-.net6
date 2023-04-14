using Microsoft.AspNetCore.Mvc;
using webapi_Francisco_1033769977.Services;
using webapi_Francisco_1033769977.Models;

namespace webapi_Francisco_1033769977.Controllers
{
    [Route("api/[Controller]")]
    public class StudentController : ControllerBase // define class StudentController and inherit from ControllerBase
    {
        IStudentsService studentsService; // declare interface object for service

        public StudentController(IStudentsService service) // define constructor to inject service dependency
        {
            studentsService = service; // initialize service object
        }

        [HttpGet]
        public IActionResult Get() // define method for HttpGet request
        {
            return Ok(studentsService.get()); // return result of service method wrapped in Ok response
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student) // define method for HttpPost request with student object as parameter
        {
            studentsService.Save(student); // call service method to save student
            return Ok();
        }

        [HttpPut("IdStudent")] // define HttpPut route with route parameter
        public IActionResult Put(Guid IdStudent,[FromBody] Student student) // define method for HttpPut request with IdStudent and student objects as parameters
        {
            studentsService.Update(IdStudent, student); // call service method to update student
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid IdStudent) // define method for HttpDelete request with IdStudent and student objects as parameters
        {
            studentsService.Delete(IdStudent); // call service method to delete student
            return Ok();
        }
    }
}
