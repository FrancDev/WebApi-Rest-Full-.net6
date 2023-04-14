
using Microsoft.AspNetCore.Mvc;
using webapi_Francisco_1033769977.Services;
using webapi_Francisco_1033769977.Models;
namespace webapi_Francisco_1033769977.Controllers

{
    [Route("api/[Controller]")]
    public class CoursesController : ControllerBase // define class CoursesController and inherit from ControllerBase
    {
        ICourseService courseService;// declare interface object for service

        public CoursesController(ICourseService service)// define constructor to inject service dependency
        {
            courseService = service;// initialize service object
        }


        [HttpGet]
        public IActionResult Get()// define method for HttpGet request
        {
            return Ok(courseService.get());// return result of service method wrapped in Ok response
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)// define method for HttpPost request with course object as parameter
        {
            courseService.Save(course);// call service method to save course
            return Ok();
        }

        [HttpPut("IdCourse")]// define HttpPut route with route parameter
        public IActionResult Put(Guid IdCourse,[FromBody] Course course)// define method for HttpPut request with IdCourse and course objects as parameters
        {
            courseService.Update(IdCourse,course );//call service method to update course
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid IdCourse)// define method for HttpDelete request with IdCourse and course objects as parameters
        {
            courseService.Delete(IdCourse);//call service method to delete course
            return Ok();
        }

    }
}