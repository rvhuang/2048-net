using Xunit;
using Xunit.Abstractions;

namespace TwoZeroFourEight.Test
{
    public class UnitTestMoveLeft
    {
        private readonly ITestOutputHelper output;

        public UnitTestMoveLeft(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = nameof(MoveLeftTestCase1))]
        public void MoveLeftTestCase1()
        {
            var input = new int[] { 2, 2, 2, 2 };
            var expected = new int[] { 4, 4, 0, 0 };

            var modified = Helper.MoveLeft(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }

        [Fact(DisplayName = nameof(MoveLeftTestCase2))]
        public void MoveLeftTestCase2()
        {
            var input = new int[] { 2, 0, 0, 2 };
            var expected = new int[] { 4, 0, 0, 0 };

            var modified = Helper.MoveLeft(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }

        [Fact(DisplayName = nameof(MoveLeftTestCase3))]
        public void MoveLeftTestCase3()
        {
            var input = new int[] { 0, 2, 1, 2 };
            var expected = new int[] { 2, 1, 2, 0 };

            var modified = Helper.MoveLeft(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }

        [Fact(DisplayName = nameof(MoveLeftTestCase4))]
        public void MoveLeftTestCase4()
        {
            var input = new int[] { 2, 0, 2, 2 };
            var expected = new int[] { 4, 2, 0, 0 };

            var modified = Helper.MoveLeft(input);

            output.WriteLine(string.Join(", ", input));

            Assert.True(modified);
            Assert.Equal<int>(expected, input);
        }
    }
}
