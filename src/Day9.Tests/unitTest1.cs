using System;
using Xunit;

namespace Day9.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1Example()
        {
            var res = new XMASencryption("input_example.txt").findInvalidVal(5);
            Assert.Equal(127, res.val);
        }

        [Fact]
        public void Task2Real()
        {
            var res = new XMASencryption("input.txt").findInvalidVal(25);
            Assert.Equal(14144619, res.val);
        }
    }
}
