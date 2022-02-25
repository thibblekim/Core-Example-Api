using Microsoft.AspNetCore.Mvc;
using UsersGroupsCoreApi.Models;

namespace UsersGroupsCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersInGroupController : ControllerBase
    {

        private readonly UsersGroupsContext _context;
        private readonly ILogger<UserController> _logger;

        public UsersInGroupController(UsersGroupsContext context, ILogger<UserController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost(Name = "Add")]
        public bool Add(int id, string email)
        {
            try
            {
                var groups = _context.UsersInGroups.Any(x => x.GroupId == id && x.UserId == email);
                if (groups == true)
                {
                    return false;
                }
                else
                {
                    var entry = new UsersInGroup
                    {
                        GroupId = id,
                        UserId = email
                    };

                    _context.UsersInGroups.Add(entry);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        [HttpPost(Name = "Remove")]
        public bool Remove(int id, string email)
        {
            try
            {
                var groups = _context.UsersInGroups.FirstOrDefault(x => x.GroupId == id && x.UserId == email);
                if (groups == null)
                {
                    return false;
                }
                else
                {                    
                    _context.UsersInGroups.Remove(groups);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }

        }
    }        
}