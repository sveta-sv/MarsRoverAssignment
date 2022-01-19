namespace MarsRoverAssignment
{
    public enum Direction { North, South, East, West }

    public enum Command { Forward, Backward, Left, Right }

    public class Rover
    {
        private int x;
        private int y;
        private Direction direction;
        private Planet planet;

        public Rover(int x, int y, Direction direction, Planet planet)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.planet = planet;
        }

        public int X { get { return x; } }

        public int Y { get { return y; } }

        public Direction Direction { get { return direction; } }

        public bool Execute(Command[] commands)
        {
            foreach (var command in commands)
            {
                if (command == Command.Left || command == Command.Right)
                {
                    Turn(command);
                }

                if (command == Command.Forward || command == Command.Backward)
                {
                    if (!Move(command))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Turn(Command command)
        {
            switch (direction)
            {
                case Direction.North:
                    if (command == Command.Left) { direction = Direction.West; }
                    if (command == Command.Right) { direction = Direction.East; }
                    break;

                case Direction.South:
                    if (command == Command.Left) { direction = Direction.East; }
                    if (command == Command.Right) { direction = Direction.West; }
                    break;

                case Direction.East:
                    if (command == Command.Left) { direction = Direction.North; }
                    if (command == Command.Right) { direction = Direction.South; }
                    break;

                case Direction.West:
                    if (command == Command.Left) { direction = Direction.South; }
                    if (command == Command.Right) { direction = Direction.North; }
                    break;
            }
        }

        private bool Move(Command command)
        {
            int newX = 0;
            int newY = 0;

            switch (direction)
            {
                case Direction.North:
                    if (command == Command.Forward) { newX = x; newY = y - 1; }
                    if (command == Command.Backward) { newX = x; newY = y + 1; }
                    break;

                case Direction.South:
                    if (command == Command.Forward) { newX = x; newY = y + 1; }
                    if (command == Command.Backward) { newX = x; newY = y - 1; }
                    break;

                case Direction.East:
                    if (command == Command.Forward) { newX = x + 1; newY = y; }
                    if (command == Command.Backward) { newX = x - 1; newY = y; }
                    break;

                case Direction.West:
                    if (command == Command.Forward) { newX = x - 1; newY = y; }
                    if (command == Command.Backward) { newX = x + 1; newY = y; }
                    break;
            }

            if (!planet.HasObstacle(newX, newY))
            {
                x = newX;
                y = newY;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
