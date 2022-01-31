using CodecChallenge.Program.Enums;

namespace CodecChallenge.Program.Entities
{
    public class Robot
    {
        private const string LEFT_COMMAND = "L";
        private const string RIGHT_COMMAND = "R";
        private const string FORWARD_COMMAND = "F";

        public Robot(string plateauSize, string commands)
        {
            Commands = commands;
            X = 1;
            Y = 1;
            Direction = Direction.NORTH;

            string[] size = plateauSize.Split("x");
            MaxX = Convert.ToInt32(size[0]);
            MaxY = Convert.ToInt32(size[1]);
            Result = string.Empty;
        }

        private int X { get; set; }
        private int Y { get; set; }
        private int MaxX { get; set; }
        private int MaxY { get; set; }
        private string Commands { get; set; }
        private Direction Direction { get; set; }
        private string Result { get; set; }

        public void Calculate()
        {
            if (!string.IsNullOrWhiteSpace(Result))
            {
                return;
            }

            foreach (var command in Commands)
            {
                Calculate(command.ToString());
            }

            Result = $"{X},{Y},{Direction.Name}";
        }

        private void Calculate(string command)
        {
            switch (command)
            {
                case LEFT_COMMAND:
                    HandleLeftCommand();
                    break;
                case RIGHT_COMMAND:
                    HandleRightCommand();
                    break;
                case FORWARD_COMMAND:
                    HandleForwardCommand();
                    break;
            }
        }

        private void HandleLeftCommand()
        {
            Direction = Direction.MoveLeft();
        }

        private void HandleRightCommand()
        {
            Direction = Direction.MoveRight();
        }

        private void HandleForwardCommand()
        {
            if (Direction.Position == Direction.NORTH.Position)
            {
                MoveY(1);
            }
            else if (Direction.Position == Direction.SOUTH.Position)
            {
                MoveY(-1);
            }
            else if (Direction.Position == Direction.EAST.Position)
            {
                MoveX(1);
            }
            else if (Direction.Position == Direction.WEST.Position)
            {
                MoveX(-1);
            }

        }

        private void MoveY(int value)
        {
            int newPosition = Y + value;

            if (newPosition == 0 || newPosition > MaxY)
            {
                return;
            }

            Y = newPosition;
        }

        private void MoveX(int value)
        {
            int newPosition = X + value;

            if (newPosition == 0 || newPosition > MaxX)
            {
                return;
            }

            X = newPosition;
        }

        public string GetResult()
        {
            return Result;
        }
    }
}