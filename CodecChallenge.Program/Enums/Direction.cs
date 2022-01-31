namespace CodecChallenge.Program.Enums
{
    public class Direction
    {
        public static Direction NORTH = new Direction("North", 1);
        public static Direction EAST = new Direction("East", 2);
        public static Direction SOUTH = new Direction("South", 3);
        public static Direction WEST = new Direction("West", 4);

        private static int MIN = 1;
        private static int MAX = 4;
        private static Dictionary<int, Direction> positions = new Dictionary<int, Direction>
        {
            { 1, NORTH},
            { 2, EAST},
            { 3, SOUTH},
            { 4, WEST},
        };

        public Direction(string name, int position)
        {
            Name = name;
            Position = position;
        }
        public string Name { get; }
        public int Position { get; }

        public Direction MoveLeft()
        {
            int newPosition = Position - 1;

            if (newPosition < MIN)
            {
                newPosition = MAX;
            }

            return positions[newPosition];
        }

        public Direction MoveRight()
        {
            int newPosition = Position + 1;

            if (newPosition > MAX)
            {
                newPosition = MIN;
            }

            return positions[newPosition];
        }
    }
}

