using Microsoft.AspNetCore.Mvc;
using UsersGroupsCoreApi.Models;
using Newtonsoft.Json;

namespace UsersGroupsCoreApi.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class GroupController : ControllerBase
    {

        private readonly UsersGroupsContext _context;
        private readonly ILogger<UserController> _logger;

        public GroupController(UsersGroupsContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("GetGroups")]
        public IEnumerable<object> GetGroups()
        {
            var groupsData = new List<object>();
            try
            {
                var groups = _context.Groups.ToList();

                foreach (var group in groups)
                {
                    groupsData.Add(JsonConvert.SerializeObject(group));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return groupsData;

        }

        [HttpGet("GetGroup")]
        public object GetGroup(int id)
        {
            var group = _context.Groups.FirstOrDefault(x => x.GroupId == id);
            return JsonConvert.SerializeObject(group);
        }

        [HttpPost("CreateGroup")]
        public object CreateGroup(string groupData)
        {
            try
            {
                var group = JsonConvert.DeserializeObject<Group>(groupData);
                if (group != null)
                {
                    _context.Groups.Add(group);
                    _context.SaveChanges();
                    return JsonConvert.SerializeObject(group);
                }

                return string.Empty;
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return string.Empty;
        }


        [HttpDelete("DeleteGroup")]
        public bool DeleteGroup(int id)
        {
            try
            {
                var group = _context.Groups.FirstOrDefault(x => x.GroupId == id);
                if (group != null)
                {
                    _context.Remove(group);
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