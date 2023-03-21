using Newtonsoft.Json;

namespace RobloxPresenceBruh;

public class UsersManager
{
    private List<User> _users = new List<User>();
    HttpClient _client = new HttpClient(); 
    
    public async Task AddUsers()
    {
        string usernames = "";
        
        Console.WriteLine("Input usernames.");
        while (true)
        {
            string? username = Console.ReadLine();
            if (string.IsNullOrEmpty(username)) break;
            usernames+="\"" + username +  "\",";
        }
        usernames = usernames.Remove(usernames.Length - 1, 1);

        StringContent requestBody = new StringContent("{ \"usernames\": [ " + usernames + " ] }");

        HttpResponseMessage response = await _client.PostAsync("https://users.roblox.com/v1/usernames/users", requestBody);

        string json = await response.Content.ReadAsStringAsync();

        dynamic data = JsonConvert.DeserializeObject<dynamic>(json)!;

        foreach (var user in data.data)
        {
            long id = user.id;
            string username = user.name;

            User newUser = new User(id, username);
            _users.Add(newUser);
        }

        _users = _users.OrderBy(x => x.Id).ToList();
    }

    public void ShowUsers()
    {
        foreach (User user in _users)
        {
            Console.WriteLine(user.ToString());
        }
    }

    public async Task UpdateUsersStatus()
    {
        string ids = "";
        foreach (User user in _users)
        {
            ids+=user.Id +  ",";
        }
        
        StringContent requestBody = new StringContent("{ \"userIds\": [ " + ids + " ] }");

        HttpResponseMessage response = await _client.PostAsync("https://presence.roblox.com/v1/presence/users", requestBody);
        
        string json = await response.Content.ReadAsStringAsync();
        
        dynamic data = JsonConvert.DeserializeObject<dynamic>(json)!;

        for (int i = 0; i < _users.Count; i++)
        {
            if (data.userPresences[i].userPresenceType == 2) _users[i].WentOnline();
            else _users[i].WentOffline();
        }
    }

    public void PlayBruhSoundEffect()
    {
        string soundPath = "bruh.wav"; 
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath);
        foreach (User user in _users)
        {
            if(!user.IsOnline())return;
        }

        Console.WriteLine("All players online. Playing Bruh Sound effect.");
        player.Play();
    }
    
}