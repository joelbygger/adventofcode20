using Xunit;

namespace Day1.Tests
{
    public class Day1Test
    {
        [Fact]
        public void task1ExampleInput()
        {
            using var sr = new System.IO.StreamReader("day1_example.txt");
            var exp = new ExpenseReport.ExpenseReport(sr);
            int? res = exp.multiplyValsWithSum2020(2);
            Assert.Equal(514579, res);
        }

        [Fact]
        public void task1realInput()
        {
            using var sr = new System.IO.StreamReader("day1.txt");
            var exp = new ExpenseReport.ExpenseReport(sr);
            int? res = exp.multiplyValsWithSum2020(2);
            Assert.Equal(927684, res);
        }

        [Fact]
        public void task2ExampleInput()
        {
            using var sr = new System.IO.StreamReader("day1_example.txt");
            var exp = new ExpenseReport.ExpenseReport(sr);
            int? res = exp.multiplyValsWithSum2020(3);
            Assert.Equal(241861950, res);
        }

        [Fact]
        public void task2RealInput()
        {
            using var sr = new System.IO.StreamReader("day1.txt");
            var exp = new ExpenseReport.ExpenseReport(sr);
            int? res = exp.multiplyValsWithSum2020(3);
            Assert.Equal(292093004, res);
        }
    }
}
