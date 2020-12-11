using Xunit;

namespace Day9.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1Example()
        {
            var res = new XMASencryption("input_example.txt").invalidVal(5);
            Assert.Equal(127, res.val);
        }

        [Fact]
        public void Task1Real()
        {
            var res = new XMASencryption("input.txt").invalidVal(25);
            Assert.Equal(14144619, res.val);
        }

        [Fact]
        public void Task2Example()
        {
            var res = new XMASencryption("input_example.txt").extremesInWindowSum(127);
            Assert.Equal(62, res);
        }

        [Fact]
        public void Task2Real()
        {
            var res = new XMASencryption("input.txt").extremesInWindowSum(14144619);
            Assert.Equal(1766397, res);
        }
    }
}
