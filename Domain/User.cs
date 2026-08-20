namespace Domain;

public class User
{
    private const int MinimumPasswordLength = 10;
    private int _userId;
    private string _password;
    public string Username { get; private set; }
    
    public User(string name, string password)
    {
        SetName(name);
        SetPassword(password);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
        Username = name;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be null or whitespace");
        }
        
        if (_password.Length < MinimumPasswordLength)
        {
            throw new ArgumentException($"Password must contain at least {MinimumPasswordLength} characters.");
        }
        _password = password;
    }

    public override string ToString()
    {
        return Username;
    }
}