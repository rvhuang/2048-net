using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TwoZeroFourEight.Test
{
    public class UnitTestMoveUp
    {
        private readonly ITestOutputHelper output;

        public UnitTestMoveUp(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = nameof(MoveUpTestCase1))]
        public void MoveUpTestCase1()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 2, 0, 0 },
                new int[] { 0, 0, 0, 2 },
                new int[] { 0, 0, 2, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 2, 0 },
                new int[] { 0, 2, 0, 0 },
                new int[] { 0, 0, 0, 2 },
                new int[] { 0, 0, 0, 0 }
            };
            var modified = Helper.MoveUp(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }

        [Fact(DisplayName = nameof(MoveUpTestCase2))]
        public void MoveUpTestCase2()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 2, 0 },
                new int[] { 4, 0, 0, 0 },
                new int[] { 4, 0, 2, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 4, 0 },
                new int[] { 0, 0, 0, 0 },
                new int[] { 4, 0, 0, 0 },
                new int[] { 4, 0, 0, 0 }
            };
            var modified = Helper.MoveUp(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }

        [Fact(DisplayName = nameof(MoveUpTestCase3))]
        public void MoveUpTestCase3()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 2, 0 },
                new int[] { 4, 0, 2, 0 },
                new int[] { 4, 0, 2, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 4, 0 },
                new int[] { 0, 0, 2, 0 },
                new int[] { 4, 0, 0, 0 },
                new int[] { 4, 0, 0, 0 }
            };
            var modified = Helper.MoveUp(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }

        [Fact(DisplayName = nameof(MoveUpTestCase4))]
        public void MoveUpTestCase4()
        {
            var input = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 0, 2, 0 },
                new int[] { 4, 0, 4, 0 },
                new int[] { 4, 0, 2, 0 }
            };
            var expected = new int[][]
            {
                new int[] { 0, 0, 2, 0 },
                new int[] { 0, 0, 4, 0 },
                new int[] { 4, 0, 2, 0 },
                new int[] { 4, 0, 0, 0 }
            };
            var modified = Helper.MoveUp(input, 2);

            output.WriteLine(string.Join(Environment.NewLine, input.Select(r => string.Join(", ", r))));

            Assert.True(modified);
            Assert.Equal<int>(expected[0], input[0]);
            Assert.Equal<int>(expected[1], input[1]);
            Assert.Equal<int>(expected[2], input[2]);
            Assert.Equal<int>(expected[3], input[3]);
        }
    }
}
