using System.IO;
using Xunit;

namespace Day4.Tests
{
    public class unitTest
    {
        [Fact]
        public void task1ExampleInput()
        {
            using var sr = new StreamReader("input_example.txt");
            var passport = new Passport(sr);
            Assert.Equal(2, passport.countValid());
        }

        [Fact]
        public void task1RealInput()
        {
            using var sr = new StreamReader("input.txt");
            var passport = new Passport(sr);
            Assert.Equal(2, passport.countValid());
        }
    }
}
