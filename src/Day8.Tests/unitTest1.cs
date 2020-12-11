using System;
using Xunit;

namespace Day8.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1ExampleInput()
        {
            var exec = new Executor(new Program("input_example.txt").get);
            Assert.Equal(5, exec.run()); ;
        }

        [Fact]
        public void Task1RealInput()
        {
            var exec = new Executor(new Program("input.txt").get);
            Assert.Equal(1810, exec.run()); ;
        }
    }
}
