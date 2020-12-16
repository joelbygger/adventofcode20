using System.Collections.Generic;
using Xunit;

namespace Day8.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Task1ExampleInput()
        {
            var exec = new Executor(new Program("input_example.txt").get);
            var res = exec.run();
            Assert.Equal(5, res.accumulator);
            Assert.True(res.infiniteLoop);
        }

        [Fact]
        public void Task1RealInput()
        {
            var exec = new Executor(new Program("input.txt").get);
            var res = exec.run();
            Assert.Equal(1810, res.accumulator);
            Assert.True(res.infiniteLoop);
        }

        [Fact]
        public void Task2EampleInput()
        {
            var prgm = new Program("input_example.txt");
            var res = new List<(int accumulator, bool infiniteLoop)>();

            foreach (var prgmVer in prgm.getModified(Program.OpCodes.jmp, Program.OpCodes.nop)) {
                res.Add(new Executor(prgmVer).run());
            }

            Assert.Equal(3, res.Count);
            Assert.Equal(4, res[0].accumulator);
            Assert.True(res[0].infiniteLoop);
            Assert.Equal(-94, res[1].accumulator);
            Assert.True(res[1].infiniteLoop);
            Assert.Equal(8, res[2].accumulator);
            Assert.False(res[2].infiniteLoop);
        }

        [Fact]
        public void Task2RealInput()
        {
            var prgm = new Program("input.txt");

            foreach (var prgmVer in prgm.getModified(Program.OpCodes.jmp, Program.OpCodes.nop)) {
                var res = new Executor(prgmVer).run();
                if (!res.infiniteLoop) {
                    Assert.Equal(969, res.accumulator);
                }
            }
        }
    }
}
