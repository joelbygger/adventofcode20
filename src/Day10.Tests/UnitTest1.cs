using Xunit;

namespace Day10.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1Example1()
        {
            var adapter = new AdapterSorting("input_example1.txt");
            Assert.Equal(35, adapter.getSum1and3StepInChain());
        }

        [Fact]
        public void Task1Example2()
        {
            var adapter = new AdapterSorting("input_example2.txt");
            Assert.Equal(220, adapter.getSum1and3StepInChain());
        }

        [Fact]
        public void Task1Real()
        {
            var adapter = new AdapterSorting("input.txt");
            Assert.Equal(1690, adapter.getSum1and3StepInChain());
        }

        [Fact]
        public void Task2Example1()
        {
            var adapter = new AdapterSorting("input_example1.txt");
            Assert.Equal(8, adapter.findAdapterCombinations(adapter.getMaxAdapterJolt()));
        }

        [Fact]
        public void Task2Example2()
        {
            var adapter = new AdapterSorting("input_example2.txt");
            Assert.Equal(19208, adapter.findAdapterCombinations(adapter.getMaxAdapterJolt()));
        }

        [Fact]
        public void Task2Real()
        {
            var adapter = new AdapterSorting("input.txt");
            Assert.Equal(5289227976704, adapter.findAdapterCombinations(adapter.getMaxAdapterJolt()));
        }
    }
}
