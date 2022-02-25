using Microsoft.AspNetCore.Mvc;
using UsersGroupsCoreApi.Models;
using Newtonsoft.Json;

namespace UsersGroupsCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {

        private readonly UsersGroupsContext _context;
        private readonly ILogger<UserController> _logger;

        public GroupController(UsersGroupsContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetGroups")]
        public IEnumerable<object> Get()
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

        [HttpGet(Name = "GetGroup")]
        public object Get(int id)
        {
            var group = _context.Groups.FirstOrDefault(x => x.GroupId == id);
            return JsonConvert.SerializeObject(group);
        }

        [HttpPost(Name = "CreateGroup")]
        public object Create(string groupData)
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


        [HttpDelete(Name = "DeleteGroup")]
        public bool Delete(int id)
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