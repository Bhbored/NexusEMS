using System.Threading.Tasks;

namespace NexusEMS.Web.Services
{
    public class AuthService
    {
        public async Task<bool> Login(string username, string password)
        {
            // Mock implementation for build success
            await Task.Delay(100);
            return true;
        }
    }
}
