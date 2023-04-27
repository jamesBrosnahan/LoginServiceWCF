Console.Write("Username: ");
var username = Console.ReadLine();

Console.Write("Password: ");
var password = Console.ReadLine();

var client = new AuthServiceClient();
var isValid = client.ValidateUser(username, password);

if (isValid)
{
    Console.WriteLine("Welcome, " + username);
}
else
{
    Console.WriteLine("Invalid username or password");
}

Console.ReadKey();