using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AuthWebService
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        bool ValidateUser(string username, string password);
    }
}
