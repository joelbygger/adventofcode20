using Xunit;

namespace Day1.Tests
{
    public class Day1Test
    {
        [Fact]
        public void task1ExampleInput()
        {
            using var sr = new System.IO.StreamReader("day1_example.txt");
            int? res = ExpenseReport.ExpenseReport.multiplyValsWithSum2020(sr, 2);
            Assert.Equal(514579, res);
        }

        [Fact]
        public void task1realInput()
        {
            using var sr = new System.IO.StreamReader("day1.txt");
            int? res = ExpenseReport.ExpenseReport.multiplyValsWithSum2020(sr, 2);
            Assert.Equal(927684, res);
        }

        [Fact]
        public void task2ExampleInput()
        {
            using var sr = new System.IO.StreamReader("day1_example.txt");
            int? res = ExpenseReport.ExpenseReport.multiplyValsWithSum2020(sr, 3);
            Assert.Equal(241861950, res);
        }

        [Fact]
        public void task2RealInput()
        {
            using var sr = new System.IO.StreamReader("day1.txt");
            int? res = ExpenseReport.ExpenseReport.multiplyValsWithSum2020(sr, 3);
            Assert.Equal(292093004, res);
        }
    }
}
