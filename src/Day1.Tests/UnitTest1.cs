using Xunit;

namespace Day1.Tests
{
    public class Day1Test
    {
        [Fact]
        public void exampleInput()
        {
            using var sr = new System.IO.StreamReader("day1_example.txt");
            int? res = ExpenseReport.ExpenseReport.multiplyValsWithSum2020(sr);
            Assert.Equal(514579, res);
        }

        [Fact]
        public void realInput()
        {
            using var sr = new System.IO.StreamReader("day1.txt");
            int? res = ExpenseReport.ExpenseReport.multiplyValsWithSum2020(sr);
            Assert.Equal(927684, res);
        }
    }
}
