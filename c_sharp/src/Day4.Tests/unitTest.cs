using System.IO;
using Xunit;

namespace Day4.Tests
{
    public class unitTest
    {
        [Fact]
        public void task1ExampleInput()
        {
            var passport = new Passport(new StreamReader("input_example.txt"));
            Assert.Equal(2, passport.countValid(false));
        }

        [Fact]
        public void task1RealInput()
        {
            var passport = new Passport(new StreamReader("input.txt"));
            Assert.Equal(237, passport.countValid(false));
        }

        [Fact]
        public void task2ExampleInput()
        {
            var passport = new Passport(new StreamReader("input_example.txt"));
            Assert.Equal(2, passport.countValid(true));
        }

        [Fact]
        public void task2ExampleInputInvalids()
        {
            var passport = new Passport(new StreamReader("input_example_invalid.txt"));
            Assert.Equal(0, passport.countValid(true));
        }

        [Fact]
        public void task2ExampleInputValids()
        {
            var passport = new Passport(new StreamReader("input_example_valid.txt"));
            Assert.Equal(4, passport.countValid(true));
        }

        [Fact]
        public void task2RealInput()
        {
            var passport = new Passport(new StreamReader("input.txt"));
            Assert.Equal(172, passport.countValid(true));
        }
    }
}
