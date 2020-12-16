using Xunit;

namespace Day7.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1ExampleInput()
        {
            var bags = new BagSorting("input_example.txt");
            Assert.Equal(4, bags.bagsThatCanContain("shiny gold"));
        }

        [Fact]
        public void Task1RealInput()
        {
            var bags = new BagSorting("input.txt");
            Assert.Equal(372, bags.bagsThatCanContain("shiny gold"));
        }

        [Fact]
        public void Task2Example1Input()
        {
            var bags = new BagSorting("input_example.txt");
            Assert.Equal(32, bags.bagsInBag("shiny gold"));
        }

        [Fact]
        public void Task2Example2Input()
        {
            var bags = new BagSorting("input_example2.txt");
            Assert.Equal(126, bags.bagsInBag("shiny gold"));
        }

        [Fact]
        public void Task2RealInput()
        {
            var bags = new BagSorting("input.txt");
            Assert.Equal(8015, bags.bagsInBag("shiny gold"));
        }
    }
}
