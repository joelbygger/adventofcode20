using System;
using Xunit;

namespace Day5.Test
{
    public class unitTest
    {
        [Fact]
        public void Task1Example1Input()
        {
            Assert.Equal(567, PlaneSeats.calcMaxId("input_example1.txt"));
        }

        [Fact]
        public void Task1Example2Input()
        {
            Assert.Equal(119, PlaneSeats.calcMaxId("input_example2.txt"));
        }

        [Fact]
        public void Task1Example3Input()
        {
            Assert.Equal(820, PlaneSeats.calcMaxId("input_example3.txt"));
        }

        [Fact]
        public void Task1RealInput()
        {
            Assert.Equal(806, PlaneSeats.calcMaxId("input.txt"));
        }
    }
}
