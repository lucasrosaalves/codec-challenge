using Xunit;
using CodecChallenge.Program.Entities;

namespace CodecChallenge.Tests;

public class RobotTests
{
    [Fact]
    public void ValidateRobotPosition()
    {
        string plateauSize = "5x5";

        string commands = "FFRFLFLF";

        var robot = new Robot(plateauSize, commands);

        robot.Calculate();

        Assert.Equal("1,4,West", robot.GetResult());
    }
}