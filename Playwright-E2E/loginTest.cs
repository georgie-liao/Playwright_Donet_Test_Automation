using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Playwright_E2E.Pages;

namespace Playwright_E2E;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {
        var loginAction = new loginPage(Page);
        await loginAction.ClickLogin();
        await loginAction.Login("admin", "password");
        var isExist = await loginAction.IsEmployeeDetailsExists();
        Assert.IsTrue(isExist);
    }
}