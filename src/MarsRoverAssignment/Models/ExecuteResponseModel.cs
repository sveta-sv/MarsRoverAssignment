namespace MarsRoverAssignment.Models
{
    public class ExecuteResponseModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public bool ObstacleEncountered { get; set; }
    }
}
