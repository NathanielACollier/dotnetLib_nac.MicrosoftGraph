using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class Service_UserTests
{
    
    
    [TestMethod]
    public async Task GetCurrentUser()
    {
        var currentUser = await lib.shared.graph.User.getCurrentUser();
        
        Assert.IsTrue(!string.IsNullOrWhiteSpace(currentUser.UserPrincipalName));
    }
}