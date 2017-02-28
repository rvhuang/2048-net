using Xunit;
using Xunit.Abstractions;

namespace TwoZeroFourEight.Test
{
    public class UnitTestMoveRight
    {
        private readonly ITestOutputHelper output;

        public UnitTestMoveRight(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = nameof(MoveRightTestCase1))]
        public void MoveRightTestCase1()
        {
            var input = new int[] { 2, 2, 2, 2 };
            var expected = new int[] { 0, 0, 4, 4 };

            var modified = Helper.MoveRight(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }

        [Fact(DisplayName = nameof(MoveRightTestCase2))]
        public void MoveRightTestCase2()
        {
            var input = new int[] { 2, 0, 0, 2 };
            var expected = new int[] { 0, 0, 0, 4 };

            var modified = Helper.MoveRight(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }

        [Fact(DisplayName = nameof(MoveRightTestCase3))]
        public void MoveRightTestCase3()
        {
            var input = new int[] { 2, 1, 2, 0 };
            var expected = new int[] { 0, 2, 1, 2 };

            var modified = Helper.MoveRight(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }

        [Fact(DisplayName = nameof(MoveRightTestCase4))]
        public void MoveRightTestCase4()
        {
            var input = new int[] { 2, 0, 2, 2 };
            var expected = new int[] { 0, 0, 2, 4 };

            var modified = Helper.MoveRight(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }
    }
}
