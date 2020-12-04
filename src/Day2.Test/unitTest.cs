using Xunit;

namespace Day2.Test
{
    public class unitTest
    {
        [Fact]
        public void task1ExampleInput()
        {
            using var sr = new System.IO.StreamReader("day2_example.txt");
            var pass = new Passwords(sr);
            Assert.Equal(2, pass.countValid());
        }

        [Fact]
        public void task1RealInput()
        {
            using var sr = new System.IO.StreamReader("day2.txt");
            var pass = new Passwords(sr);
            Assert.Equal(483, pass.countValid());
        }
    }
}
