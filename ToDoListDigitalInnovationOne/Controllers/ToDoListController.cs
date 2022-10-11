using Microsoft.AspNetCore.Mvc;

namespace ToDoListDigitalInnovationOne.Controllers
{
    [ApiController]
    [Route("controler")]
    public class ToDoListController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddToDo()
        {
            // fazer um dto de post - adicionar o automapper...
        }
    }
}
