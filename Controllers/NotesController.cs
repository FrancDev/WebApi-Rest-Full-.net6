using Microsoft.AspNetCore.Mvc;
using webapi_Francisco_1033769977.Services; 
using webapi_Francisco_1033769977.Models; 
namespace webapi_Francisco_1033769977.Controllers 
{
    [Route("api/[Controller]")] 
    public class NotesController : ControllerBase // Define the NotesController class and inherit from ControllerBase
    {
        INotesService notesService; // Declare an interface object for the Notes service

        public NotesController(INotesService service) // Define a constructor to inject the service dependency
        {
            notesService = service; // Initialize the service object
        }

        [HttpGet]
        public IActionResult Get() // Define a method for HTTP GET requests
        {
            return Ok(notesService.get()); // Return the result of the service method wrapped in an OK response
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note note) // Define a method for HTTP POST requests with a Note object as a parameter
        {
            notesService.Save(note); // Call the service method to save the Note
            return Ok();
        }

        [HttpPut("IdNote")]
        public IActionResult Put(Guid IdNote,[FromBody] Note note) // Define a method for HTTP PUT requests with IdNote and Note objects as parameters
        {
            notesService.Update(IdNote,note ); // Call the service method to update the Note
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid IdNote) // Define a method for HTTP DELETE requests with an IdNote parameter
        {
            notesService.Delete(IdNote); // Call the service method to delete the Note
            return Ok();
        }
    }
}
