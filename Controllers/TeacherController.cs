using Microsoft.AspNetCore.Mvc;
using webapi_Francisco_1033769977.Services;
using webapi_Francisco_1033769977.Models;

namespace webapi_Francisco_1033769977.Controllers
{
    [Route("api/[Controller]")]
    public class TeacherController : ControllerBase // define TeacherController class and inherit from ControllerBase
    {
        ITeachersServices teachersService; // declare interface object for service

        public TeacherController(ITeachersServices service) // define constructor to inject service dependency
        {
            teachersService = service; // initialize service object
        }


        [HttpGet] // define method for HttpGet request
        public IActionResult Get()
        {
            return Ok(teachersService.get()); // return result of service method wrapped in Ok response
        }

        [HttpPost] // define method for HttpPost request with Teacher object as parameter
        public IActionResult Post([FromBody] Teacher teacher)
        {
            teachersService.Save(teacher); // call service method to save Teacher
            return Ok();
        }

        [HttpPut("IdTeacher")] // define HttpPut route with route parameter
        public IActionResult Put(Guid IdTeacher,[FromBody] Teacher teacher) // define method for HttpPut request with IdTeacher and Teacher objects as parameters
        {
            teachersService.Update(IdTeacher, teacher); //call service method to update Teacher
            return Ok();
        }

        [HttpDelete] // define method for HttpDelete request with IdTeacher as parameter
        public IActionResult Delete(Guid IdTeacher)
        {
            teachersService.Delete(IdTeacher); //call service method to delete Teacher
            return Ok();
        }    
    }
}
