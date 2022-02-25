using UsersInGroupsCore.DTO;
using Newtonsoft.Json;

namespace UsersInGroupsCore.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        //User GetUserByEmail(string email);
        //bool DeleteUser(string email);
        //User CreateUser(User user);
        //User EditUser(User user);
    }
        
    public class UserService : IUserService
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            var userList = new List<User>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7201/api/GetUsers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            return userList;
        }
    }
}
