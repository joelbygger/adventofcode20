using Xunit;

namespace Day6.Test
{
    public class unitTest
    {
        [Fact]
        public void task1ExampleInput()
        {
            Assert.Equal(11, new Questionnaire("input_example.txt").sumAllUniqueYesPerGroup());
        }

        [Fact]
        public void task1RealInput()
        {
            Assert.Equal(6799, new Questionnaire("input.txt").sumAllUniqueYesPerGroup());
        }

        [Fact]
        public void task2ExampleInput()
        {
            Assert.Equal(6, new Questionnaire("input_example.txt").sumCommonYesPerGroup());
        }

        [Fact]
        public void task2RealInput()
        {
            Assert.Equal(3354, new Questionnaire("input.txt").sumCommonYesPerGroup());
        }
    }
}
