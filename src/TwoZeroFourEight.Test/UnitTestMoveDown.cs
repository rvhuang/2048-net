using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TwoZeroFourEight.Test
{
    public class UnitTestMoveDown
    {
        private readonly ITestOutputHelper output;

        public UnitTestMoveDown(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = nameof(MoveDownTestCase1))]
        public void MoveDownTestCase1()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 2, 0 },
                new int[] { 0, 2, 0, 0 },
                new int[] { 0, 0, 0, 2 },
                new int[] { 0, 0, 0, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 2, 0, 0 },
                new int[] { 0, 0, 0, 2 },
                new int[] { 0, 0, 2, 0 }
            };
            var modified = Helper.MoveDown(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }

        [Fact(DisplayName = nameof(MoveDownTestCase2))]
        public void MoveDownTestCase2()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 2, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 4, 0, 2, 0 },
                new int[] { 4, 0, 0, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 4, 0, 0, 0 },
                new int[] { 4, 0, 4, 0 }
            };
            var modified = Helper.MoveDown(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }

        [Fact(DisplayName = nameof(MoveDownTestCase3))]
        public void MoveDownTestCase3()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 2, 0 },
                new int[] { 0, 0, 2, 0 },
                new int[] { 4, 0, 2, 0 },
                new int[] { 4, 0, 0, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 4, 0, 2, 0 },
                new int[] { 4, 0, 4, 0 }
            };
            var modified = Helper.MoveDown(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }

        [Fact(DisplayName = nameof(MoveDownTestCase4))]
        public void MoveDownTestCase4()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 2, 0 },
                new int[] { 0, 0, 4, 0 },
                new int[] { 4, 0, 2, 0 },
                new int[] { 4, 0, 0, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 2, 0 },
                new int[] { 4, 0, 4, 0 },
                new int[] { 4, 0, 2, 0 }
            };
            var modified = Helper.MoveDown(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }
    }
}
