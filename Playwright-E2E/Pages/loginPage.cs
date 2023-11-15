using Microsoft.Playwright;

namespace Playwright_E2E.Pages;

public class loginPage
{
    private readonly IPage _page;

    public loginPage(IPage page) => _page = page;
    

    private ILocator _lnkLogin => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Login" });
    private ILocator _txtUserName => _page.GetByLabel("UserName");
    private ILocator _txtPassword => _page.GetByLabel("Password");
    private ILocator _btnLogin => _page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Log in" });
    private ILocator _lnkEmployeeDetails => _page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Employee List" });
    private ILocator _lnkEmployeeLists => _page.Locator("text='Employee List'");

    
    public async Task ClickLogin()
    {
        await _lnkLogin.ClickAsync();
    }

    public async Task Login(string userName, string password)
    {
        await _txtUserName.FillAsync(userName);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExists()
    {
        return await _lnkEmployeeDetails.IsVisibleAsync();
    }
}