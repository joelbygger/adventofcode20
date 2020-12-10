using System;
using Xunit;

namespace Day8.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1ExampleInput()
        {
            var exec = new Executor(ParseProgram.readFile("input_example.txt"));
            Assert.Equal(5, exec.run()); ;
        }

        [Fact]
        public void Task1RealInput()
        {
            var exec = new Executor(ParseProgram.readFile("input.txt"));
            Assert.Equal(1810, exec.run()); ;
        }
    }
}
