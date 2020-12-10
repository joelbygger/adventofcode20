using Xunit;

namespace Day7.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1ExampleInput()
        {
            var bags = new BagSorting("input_example.txt");
            Assert.Equal(4, bags.bagColorsThatCanContainGolden());
        }

        [Fact]
        public void Task1RealInput()
        {
            var bags = new BagSorting("input.txt");
            Assert.Equal(372, bags.bagColorsThatCanContainGolden());
        }
    }
}
