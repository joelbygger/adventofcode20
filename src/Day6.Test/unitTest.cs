using Xunit;

namespace Day6.Test
{
    public class unitTest
    {
        [Fact]
        public void task1ExampleInput()
        {
            Assert.Equal(11, new Questionnaire("input_example.txt").yesCnt());
        }

        [Fact]
        public void task1RealInput()
        {
            Assert.Equal(6799, new Questionnaire("input.txt").yesCnt());
        }
    }
}
