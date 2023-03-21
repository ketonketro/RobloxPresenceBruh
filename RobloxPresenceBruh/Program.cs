using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RobloxPresenceBruh
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            UsersManager usersManager = new UsersManager();
            
            await usersManager.AddUsers();
            
            while (true)
            {
                Console.Clear();
                await usersManager.UpdateUsersStatus();
                usersManager.ShowUsers();
                usersManager.PlayBruhSoundEffect();
                await Task.Delay(5000);
            }
        }
    }
}