using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace ResourceMaster.Test.UITest
{

    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CounterCompTest : PageTest
    {
        [Test]
        public async Task IncrementCount_ShouldUpdateCurrentCount()
        {
            // Navigate to the counter page
            await Page.GotoAsync("https://localhost:7295/counter");

            // Get the initial count value
            var countElem = await Page.QuerySelectorAsync("p[role=\"status\"]");
            var initialCount = await countElem.InnerTextAsync();

            // Click the button
            var button = Page.GetByRole(AriaRole.Button, new() { Name = "Click me" });
            await button.ClickAsync();

            // Get the updated count value
            var updatedCount = await countElem.InnerTextAsync();

            await Expect(Page.Locator("p")).ToHaveTextAsync("Current count: 1");
            
            // Verify that the count was incremented
            //Assert.That(int.Parse(updatedCount), Is.EqualTo(int.Parse(initialCount) + 1));
        }
    }
}
