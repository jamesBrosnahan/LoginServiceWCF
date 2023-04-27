using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using AuthenticationLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace AuthService
{
    public partial class LoginService : ServiceBase
    {
        private readonly UserManager userManager;
        private string dataSourceName;

        public LoginService()
        {
            InitializeComponent();
            userManager = new UserManager(dataSourceName);
        }

        protected override void OnStart(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            //TODO: Load data source name from args, environment variable, or config file
            // Load data source name from arguments
            if (args.Length > 0)
            {
                dataSourceName = args[0];
            }
            else
            {
                // Load data source name from environment variable
                dataSourceName = Environment.GetEnvironmentVariable("DataSourceName");

                // If the data source name is not found in the environment variable, load it from the config file
                if (string.IsNullOrEmpty(dataSourceName))
                {
                    dataSourceName = configuration["DataSourceName"];
                }
            }
        }

        protected override void OnStop()
        {
        }
    }
}
