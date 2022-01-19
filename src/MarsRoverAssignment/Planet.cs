namespace MarsRoverAssignment
{
    public class Planet
    {
        private bool[,] surface;

        public Planet(bool[,] surface)
        {
            this.surface = surface;
        }

        public bool HasObstacle(int x, int y)
        {
            return surface[x, y];
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
