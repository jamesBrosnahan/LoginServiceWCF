using System.Data.Odbc;

namespace AuthenticationLibrary
{
    public class UserManager
    {
        private readonly string dataSourceName;

        public UserManager(string dataSourceName)
        {
            this.dataSourceName = dataSourceName;
        }

        public bool ValidateUser(string username, string password)
        {
            using (var connection = new OdbcConnection(dataSourceName))
            {
                connection.Open();

                using (var command = new OdbcCommand("SELECT COUNT(*) FROM Users WHERE Username = ? AND Password = ?", connection))
                {
                    command.Parameters.Add("@Username", OdbcType.VarChar).Value = username;
                    command.Parameters.Add("@Password", OdbcType.VarChar).Value = password;

                    var result = (int)command.ExecuteScalar();

                    return result == 1;
                }
            }
        }
    }
}