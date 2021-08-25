using Sweeters.Operations;
using Xunit;

namespace Sweeters.UnitTests
{
    public class DoTaskListVerificatorTest
    {
        [Theory]
        [InlineData("Top", "Formula One", "", "Formula One")]
        [InlineData("Top", "Formula One sort:latest", "latest", "Formula One")]
        [InlineData("Top", "Formula sort:latest One", "latest", "Formula One")]
        [InlineData("Top", "sort:latest Formula One", "latest", "Formula One")]
        [InlineData("Top", "Formula One sort:people", "Top", "Formula One")]
        [InlineData("Top", "Formula sort:people One", "Top", "Formula One")]
        [InlineData("Top", "sort:people Formula One", "Top", "Formula One")]
        [InlineData("Top", "Formula One sort:photos", "photos", "Formula One")]
        [InlineData("Top", "Formula sort:photos One", "photos", "Formula One")]
        [InlineData("Top", "sort:photos Formula One", "photos", "Formula One")]
        [InlineData("Top", "Formula One sort:videos", "videos", "Formula One")]
        [InlineData("Top", "Formula sort:videos One", "videos", "Formula One")]
        [InlineData("Top", "sort:videos Formula One", "videos", "Formula One")]
        public static void SortOptionTest(string sortOptionInput, string searchStringInput, string sortOptionExpected, string searchStringExpected)
        {
            (string sortOptionOutput, string searchStringOutput) = Methods.SortIdentifier(sortOptionInput, searchStringInput);

            Assert.Equal(sortOptionExpected, sortOptionOutput, ignoreWhiteSpaceDifferences: true);
            Assert.Equal(searchStringExpected, searchStringOutput, ignoreWhiteSpaceDifferences: true);
        }

        [Theory]
        [InlineData(10, "Formula One", 10, "Formula One")]
        [InlineData(10, "Formula One maxresults:15", 15, "Formula One")]
        [InlineData(10, "Formula One maxresults:100", 100, "Formula One")]
        [InlineData(10, "Formula maxresults:100 One", 100, "Formula One")]
        [InlineData(10, "Formula maxresults:15 One", 15, "Formula One")]
        [InlineData(10, "maxresults:15 Formula One", 15, "Formula One")]
        [InlineData(10, "maxresults:150 Formula One", 150, "Formula One")]
        public static void MaxResultIdentifierTest(int maxResultsInput, string searchStringInput, int maxResultsExpected, string searchStringExpected)
        {
            (int maxResultsOutput, string searchStringOutput) = Methods.MaxResultIdentifier(maxResultsInput, searchStringInput);

            Assert.Equal(maxResultsExpected, maxResultsOutput);
            Assert.Equal(searchStringExpected, searchStringOutput, ignoreWhiteSpaceDifferences: true);
        }
    }
}
