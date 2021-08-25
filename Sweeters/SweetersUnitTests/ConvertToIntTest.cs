using Sweeters.Operations;
using Xunit;

namespace Sweeters.UnitTests
{
    public class ConvertToIntTests
    {
        [Theory]
        [InlineData("", "", 0)]
        [InlineData(" ", "", 0)]
        [InlineData("1", "", 1)]
        [InlineData("12", "", 12)]
        [InlineData("123", "", 123)]
        [InlineData("1", "K", 1000)]
        [InlineData("1.2", "K", 1200)]
        [InlineData("12.3", "K", 12300)]
        [InlineData("123.4", "K", 123400)]
        [InlineData("1.0", "M", 1000000)]
        [InlineData("1.2", "M", 1200000)]
        [InlineData("12.3", "M", 12300000)]
        [InlineData("123.4", "M", 123400000)]
        [InlineData(";D", "M", -1)]
        [InlineData("123.4", "S", -1)]
        public static void ConvertToIntTestOverload1(string input, string multiplyer, int resultExpected)
        {
            int result = Methods.ConvertToInt(input, multiplyer);

            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("1", 1)]
        [InlineData("12", 12)]
        [InlineData("123", 123)]
        [InlineData("1K", 1000)]
        [InlineData("1.2K", 1200)]
        [InlineData("12.3K", 12300)]
        [InlineData("123.4K", 123400)]
        [InlineData("1.0M", 1000000)]
        [InlineData("1.2M", 1200000)]
        [InlineData("12.3M", 12300000)]
        [InlineData("123.4M", 123400000)]
        [InlineData(";D M", -1)]
        [InlineData("123.4S", -1)]
        public static void StringToIntHandleTest(string stringNumberInput, int resultExpected)
        {
            int result = Methods.StringToIntHandle(stringNumberInput);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("12", 12)]
        [InlineData("123", 123)]
        public static void ConvertToIntTestOverload2(string stringInput, int resultExpected)
        {
            int result = Methods.ConvertToInt(stringInput);
            Assert.Equal(resultExpected, result);
        }
    }
}
