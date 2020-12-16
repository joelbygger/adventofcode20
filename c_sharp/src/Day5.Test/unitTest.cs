using Xunit;

namespace Day5.Test
{
    public class unitTest
    {
        [Fact]
        public void Task1Example1Input()
        {
            Assert.Equal(
                567,
                new PlaneSeats("input_example1.txt").calcMaxId());
        }

        [Fact]
        public void Task1Example2Input()
        {
            Assert.Equal(
                119,
                new PlaneSeats("input_example2.txt").calcMaxId());
        }

        [Fact]
        public void Task1Example3Input()
        {
            Assert.Equal(
                820,
                new PlaneSeats("input_example3.txt").calcMaxId());
        }

        [Fact]
        public void Task1RealInput()
        {
            Assert.Equal(
                806,
                new PlaneSeats("input.txt").calcMaxId());
        }

        [Fact]
        public void Task2RealInput()
        {
            Assert.Equal(
                562,
                new PlaneSeats("input.txt").findEmptySeat());
        }
    }
}
