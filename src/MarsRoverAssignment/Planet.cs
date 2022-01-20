namespace MarsRoverAssignment
{
    public class Planet
    {
        private const int Obstacle = 1;

        private int[,] surface;

        public Planet(int[,] surface)
        {
            this.surface = surface;
        }

        public bool HasObstacle(int x, int y)
        {
            return surface[x, y] == Obstacle;
        }

        public int Height
        {
            get { return surface.GetLength(0); }
        }

        public int Width
        {
            get { return surface.GetLength(1); }
        }
    }
}
