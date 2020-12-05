using System;
using Xunit;

namespace Day3.Tests
{
    using AStep = Tuple<int, int>;

    public class unitTest
    {
        [Fact]
        public void task1ExampleInput()
        {
            using var sr = new System.IO.StreamReader("input_example.txt");
            var map = new Day3.SlopeMap(sr);
            Assert.Equal(7, map.collisionsOnTravel(xStep: 3, yStep: 1));
        }

        [Fact]
        public void task1RealInput()
        {
            using var sr = new System.IO.StreamReader("input.txt");
            var map = new Day3.SlopeMap(sr);
            Assert.Equal(171, map.collisionsOnTravel(xStep: 3, yStep: 1));
        }

        [Fact]
        public void task2ExampleInput()
        {
            using var sr = new System.IO.StreamReader("input_example.txt");
            var map = new Day3.SlopeMap(sr);
            Assert.Equal(2, map.collisionsOnTravel(xStep: 1, yStep: 1));
            Assert.Equal(7, map.collisionsOnTravel(xStep: 3, yStep: 1));
            Assert.Equal(3, map.collisionsOnTravel(xStep: 5, yStep: 1));
            Assert.Equal(4, map.collisionsOnTravel(xStep: 7, yStep: 1));
            Assert.Equal(2, map.collisionsOnTravel(xStep: 1, yStep: 2));
        }

        [Fact]
        public void task2RealInput()
        {
            using var sr = new System.IO.StreamReader("input.txt");
            var map = new Day3.SlopeMap(sr);

            AStep[] Steps = {
                new AStep(1, 1),
                new AStep(3, 1),
                new AStep(5, 1),
                new AStep(7, 1),
                new AStep(1, 2)};
            int a = 1;
            foreach (var step in Steps) {
                a *= map.collisionsOnTravel(xStep: step.Item1, yStep: step.Item2);
            }
            Assert.Equal(1206576000, a);
        }
    }
}
