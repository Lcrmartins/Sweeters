using Sweeters.Operations;
using Xunit;

namespace Sweeters.UnitTests
{
    public class UniqueHandlerTest
    {

        [Theory]
        [InlineData("https://twitter.com/NickAdamsinUSA/status/1427808585459904512", "NickAdamsinUSA/status/1427808585459904512")]
        [InlineData("https://twitter.com/maluqswest/status/1427805879764725763", "maluqswest/status/1427805879764725763")]
        [InlineData("https://twitter.com/t_dlist/status/1427628088490405890", "t_dlist/status/1427628088490405890")]
        [InlineData("gshsçlob,bi iuhop bsdsd808 0405890", "Fail to obtain data")]
        [InlineData("gshsçlob,bi iuhop bsdsd808 0405890 cjsdniuhdf0ug sgsdpbigfpoijfbj", "Fail to obtain data")]
        [InlineData("", "Fail to obtain data")]
        [InlineData(null, "Fail to obtain data")]
        public static void UniqueIdHandlerTest(string inputString, string expectedString)
        {
            string outputString = Methods.UniqueIdHandler(inputString);

            Assert.Equal(expectedString, outputString);
        }

    }
}
