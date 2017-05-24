using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExample.PageObjects;
using TechTalk.SpecFlow;

namespace SeleniumExample.Steps
{
    [Binding]
    public class ExampleSteps
    {
        private readonly HomePageObject _homePageObject;
        private readonly SearchPage _searchPage;

        public ExampleSteps(HomePageObject homePageObject, SearchPage searchPage)
        {
            _homePageObject = homePageObject;
            _searchPage = searchPage;
        }

        [BeforeScenario("Home", Order = 100000)]
        public void Open()
        {
            _homePageObject.Open();
        }

        [Given(@"I enter the search term (.*)")]
        public void GivenIEnter(string searchTerm)
        {
            _homePageObject.EnterSearchByText(searchTerm);
        }

        [When(@"I initiate the search")]
        public void WhenIInitiateTheSearch()
        {
            _homePageObject.InitiateSearch();
        }

        [Then(@"the search term title displayed is (.*)")]
        public void ThenTheSearchTermTitleDisplayedIsShorts(string searchTerm)
        {
            _searchPage.GetSearchTerm().Should().Be(searchTerm);
        }
    }
}