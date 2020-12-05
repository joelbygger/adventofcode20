using Xunit;

namespace Day3.Tests
{
    public class unitTest
    {
        [Fact]
        public void task1ExampleInput()
        {
            using var sr = new System.IO.StreamReader("input_example.txt");
            var map = new Day3.SlopeMap(sr);
            Assert.Equal(7, map.collisionsOnTravel());
        }

        [Fact]
        public void task1RealInput()
        {
            using var sr = new System.IO.StreamReader("input.txt");
            var map = new Day3.SlopeMap(sr);
            Assert.Equal(171, map.collisionsOnTravel());
        }
    }
}
