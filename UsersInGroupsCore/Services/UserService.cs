using UsersInGroupsCore.DTO;
using Newtonsoft.Json;

namespace UsersInGroupsCore.Services
{
    public interface IUserService
    {
        List<User> GetUsers();        
        bool DeleteUser(string email);
        User CreateUser(string firstName, string lastName, string email);
        User EditUser(User user);
    }

    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            var userList = new List<User>();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync("https://localhost:7201/api/GetUsers").Result)
                {

                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    //var test = JsonConvert.DeserializeObject<string>(apiResponse);
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            return userList;
        }

        public bool DeleteUser(string email)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.DeleteAsync($"https://localhost:7201/api/DeleteUser?email={email}").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else return false;                   
                    
                }
            }
        }

        public User CreateUser(string firstName, string lastName, string email)
        {
            var user = new User();
            user.FirstName = firstName; 
            user.LastName = lastName;   
            user.Email = email;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.PostAsJsonAsync($"https://localhost:7201/api/CreateUser", user).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return user;
                    }
                    else return null;

                }
            }
        }

        public User EditUser(User user)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.PutAsJsonAsync($"https://localhost:7201/api/EditUser", user).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return user;
                    }
                    else return null;

                }
            }            
        }
    }
}
