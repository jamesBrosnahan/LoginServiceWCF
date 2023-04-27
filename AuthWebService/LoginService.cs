using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationLibrary;

namespace AuthWebService
{
    public class LoginService : ILoginService
    {
        private readonly UserManager userManager;
        private string dataSourceName;

        public LoginService()
        {
            // Retrieve dataSourceName from environment variable
            dataSourceName = Environment.GetEnvironmentVariable("YourUniqueEnvironmentVariableName");

            // Set a default value if the environment variable is not set
            if (string.IsNullOrEmpty(dataSourceName))
            {
                dataSourceName = "AuthWebService";
            }

            userManager = new UserManager($"DSN={dataSourceName}");
        }

        public bool ValidateUser(string username, string password)
        {
            return userManager.ValidateUser(username, password);
        }
    }
}
