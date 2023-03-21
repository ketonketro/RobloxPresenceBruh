namespace RobloxPresenceBruh;

public class User
{
    private readonly string _username;
    private bool _online;
    private bool _wasOnline;

    public long Id { get; }


    public User(long id, string username)
    {
        Id = id;
        _username = username;
        _online = false;
        _wasOnline = false;
    }

    public void WentOnline()
    {
        _online = true;
        _wasOnline = false;
    }

    public void WentOffline()
    {
        _online = false;
        _wasOnline = true;
    }

    public bool IsOnline()
    {
        return _online && !_wasOnline;
    }

    public override string ToString()
    {
        string status = _online ? "ONLINE" : "OFFLINE";

        string spaces = "";

        for (int i = 0; i < 20 - _username.Length; i++)
        {
            spaces += " ";
        }
        
        return $"{_username}{spaces} is {status}";
    }
}