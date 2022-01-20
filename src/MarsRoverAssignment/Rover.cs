namespace MarsRoverAssignment
{
    public enum Direction { N, S, E, W }

    public enum Command { F, B, L, R }

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
                if (command == Command.L || command == Command.R)
                {
                    Turn(command);
                }

                if (command == Command.F || command == Command.B)
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
                case Direction.N:
                    if (command == Command.L) { direction = Direction.W; }
                    if (command == Command.R) { direction = Direction.E; }
                    break;

                case Direction.S:
                    if (command == Command.L) { direction = Direction.E; }
                    if (command == Command.R) { direction = Direction.W; }
                    break;

                case Direction.E:
                    if (command == Command.L) { direction = Direction.N; }
                    if (command == Command.R) { direction = Direction.S; }
                    break;

                case Direction.W:
                    if (command == Command.L) { direction = Direction.S; }
                    if (command == Command.R) { direction = Direction.N; }
                    break;
            }
        }

        private bool Move(Command command)
        {
            int newX = 0;
            int newY = 0;

            switch (direction)
            {
                case Direction.N:
                    if (command == Command.F) { newX = x; newY = y - 1; }
                    if (command == Command.B) { newX = x; newY = y + 1; }
                    break;

                case Direction.S:
                    if (command == Command.F) { newX = x; newY = y + 1; }
                    if (command == Command.B) { newX = x; newY = y - 1; }
                    break;

                case Direction.E:
                    if (command == Command.F) { newX = x + 1; newY = y; }
                    if (command == Command.B) { newX = x - 1; newY = y; }
                    break;

                case Direction.W:
                    if (command == Command.F) { newX = x - 1; newY = y; }
                    if (command == Command.B) { newX = x + 1; newY = y; }
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
