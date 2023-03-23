namespace RobloxPresenceBruh;

public class User
{
    public string Username;
    public long Id { get; }
    public int Activity { get; set; }
    public string ActivityDetails { get; set; }
    public long ActivityId { get; set; }
    public long ActivityTime { get; set; }


    public User(long id, string username)
    {
        Id = id;
        Username = username;
        Activity = 0;
    }

    public bool IsOnline()
    {
        return Activity != 0;
    }
    
    public override string ToString()
    {
        string status = "";
        string act = "";

        string spaces = "";

        for (int i = 0; i < 20 - Username.Length; i++)
        {
            spaces += " ";
        }

        switch (Activity)
        {
            case 0:
                status = "OFFLINE";
                break;
            case 1: 
                status = "ONLINE "; 
                act = "on website";
               break;
            case 2:
                status = "ONLINE ";
                act = "in game";
                break;
            case 3:
                status = "ONLINE ";
                act = "in studio";
                break;
            
        }
        
        return $"{Username}{spaces} is {status} {act} {ActivityDetails}";
    }
}