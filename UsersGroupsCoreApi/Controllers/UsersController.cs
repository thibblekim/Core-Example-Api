using Microsoft.AspNetCore.Mvc;
using UsersGroupsCoreApi.Models;
using Newtonsoft.Json;

namespace UsersGroupsCoreApi.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class UserController : ControllerBase
    {

        private readonly UsersGroupsContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(UsersGroupsContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetUsers")]
        public IEnumerable<object> GetUsers()
        {
            var usersData = new List<object>();
            try
            {
                var users = _context.Users.ToList();

                foreach (var user in users)
                {
                    usersData.Add(JsonConvert.SerializeObject(user));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return usersData;

        }

        [HttpGet("GetUser")]
        public object Get(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            return JsonConvert.SerializeObject(user);
        }

        [HttpPost("CreateUser")]
        public object Create(string userData)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<User>(userData);
                if (user != null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return JsonConvert.SerializeObject(user);
                }

                return string.Empty;
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return string.Empty;
        }


        [HttpDelete("DeleteUser")]
        public bool Delete(string email)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == email);
                if (user != null)
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;

            }
        }
    }
}