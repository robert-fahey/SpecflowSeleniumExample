using OpenQA.Selenium;
using SeleniumExample.PageObjects;
using TechTalk.SpecFlow;

namespace SeleniumExample.Steps
{
    [Binding]
    public class ExampleSteps
    {
        private readonly HomePageObject _homePageObject;

        public ExampleSteps(HomePageObject homePageObject)
        {
            _homePageObject = homePageObject;
        }

        [BeforeScenario("Home", Order = 100000)]
        public void Open()
        {
            _homePageObject.Open();
        }

        [Given(@"I search for (.*)")]
        public void GivenIClickFoo(string searchTerm)
        {
            _homePageObject.SearchByText(searchTerm);
        }

    }
}