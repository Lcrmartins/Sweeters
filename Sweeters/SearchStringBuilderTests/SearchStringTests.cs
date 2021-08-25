using ConsoleApp1;
using System.Text;
using Xunit;

namespace SearchStringBuilderTests
{
    public class SearchStringTests
    {
        [Fact]
        public void SearchStringBuildingTestAll1()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzeAllTheseWords(
                new StringBuilder(400), "all:'SpaceX Splashdown'");

            Assert.Equal("SpaceX%20Splashdown%20", SearchString.ToString());
            Assert.Equal("", Input);
        }
        [Fact]
        public void SearchStringBuildingTestAll2()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzeAllTheseWords(
                new StringBuilder(400), "'SpaceX Splashdown'");

            Assert.Equal("SpaceX%20Splashdown%20", SearchString.ToString());
            Assert.Equal("", Input);
        }

        [Fact]
        public void SearchStringBuildingPhrase1()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzePhrase(
                new StringBuilder(400), "\"SpaceX splashed in the Gulf\"");

            Assert.Equal("%22SpaceX%20splashed%20in%20the%20Gulf%22%20", SearchString.ToString());
            Assert.Equal("", Input);
        }

        [Fact]
        public void SearchStringBuildingPhrase2()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzePhrase(
                new StringBuilder(400), "phrase:\"SpaceX splashed in the Gulf\"");

            Assert.Equal("%22SpaceX%20splashed%20in%20the%20Gulf%22%20", SearchString.ToString());
            Assert.Equal("", Input);
        }

        [Fact]
        public void SearchStringBuildingAny1()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzeAnyOfTheseWords(
                new StringBuilder(400), "any:'SpaceX splash Gulf'");

            Assert.Equal("(SpaceX%20OR%20splash%20OR%20Gulf)%20", SearchString.ToString());
            Assert.Equal("", Input);
        }

        [Fact]
        public void SearchStringBuildingAny2()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzeAnyOfTheseWords(
                new StringBuilder(400), "(SpaceX splash Gulf)");

            Assert.Equal("(SpaceX%20OR%20splash%20OR%20Gulf)%20", SearchString.ToString());
            Assert.Equal("", Input);
        }

        [Fact]
        public void SearchStringBuildingNone()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzeNoneOfTheseWords(
                new StringBuilder(400), "none:'SpaceX splash Gulf'");

            Assert.Equal("-SpaceX%20-splash%20-Gulf%20", SearchString.ToString());
            Assert.Equal("", Input);
        }

        [Fact]
        public void SearchStringBuildingTags1()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzeHashTags(
                new StringBuilder(400), "tag:'#nasa #sky'");

            Assert.Equal("(%23nasa%20OR%20%23sky)%20", SearchString.ToString());
            Assert.Equal("", Input);
        }

        [Fact]
        public void SearchStringBuildingTags2()
        {
            (StringBuilder SearchString, string Input) = Analyzers.AnalyzeAnyOfTheseWords(
                new StringBuilder(400), "(#nasa #sky)");

            Assert.Equal("(%23nasa%20OR%20%23sky)%20", SearchString.ToString());
            Assert.Equal("", Input);
        }


    }
}
