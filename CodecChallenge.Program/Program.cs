using CodecChallenge.Program.Entities;

namespace CodecChallenge.Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string plateauSize = args[0];

            string commands = args[1];

            var robot = new Robot(plateauSize, commands);

            robot.Calculate();

            Console.WriteLine(robot.GetResult());
        }
    }
}