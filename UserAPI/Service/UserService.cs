using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using UserAPI.Models;

namespace UserAPI.Service
{
    public class UserService
    {
        public async Task<List<User>> GetUsersAsync()
        {
            HttpClient client = new HttpClient();
            List<User> users = null;
            //async request to get JSON result because we don't know how much time the API will take to return the result
            HttpResponseMessage response = await client.GetAsync("https://alexdmeyer.com/codetest/users.json");
            if (response.IsSuccessStatusCode)
            {
                //converting string result into c# object
                users = await response.Content.ReadAsAsync<List<User>>();
                if (users == null || users.Count == 0)
                {
                    return users;
                }
                else
                {
                    //account should be enabled and display name should contains e 
                    return users.Where(x => x.AccountEnabled && x.DisplayName.ToLower().Contains("e")).ToList();
                }
            }
            return users;
        }
    }
}