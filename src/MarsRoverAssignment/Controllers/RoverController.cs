using MarsRoverAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoverController : Controller
    {
        private Rover rover;

        public RoverController(Rover rover)
        {
            this.rover = rover;
        }

        [HttpGet]
        public string Index()
        {
            return "Hello from Mars!";
        }

        [HttpPost]
        public ExecuteResponseModel Execute(ExecuteRequestModel request)
        {
            var success = rover.Execute(request.Commands);

            var response = new ExecuteResponseModel
            {
                X = rover.X,
                Y = rover.Y,
                Direction = rover.Direction,
                ObstacleEncountered = !success
            };

            return response;
        }
    }
}
