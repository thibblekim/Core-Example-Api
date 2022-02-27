using Microsoft.AspNetCore.Mvc;
using UsersInGroupsCore.Services;
using UsersInGroupsCore.DTO;

namespace UsersInGroupsCore.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UsersController
        public ActionResult Users()
        {
            var users = _userService.GetUsers();
            
            return View(users);
        }

        // POST: UsersController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            _userService.CreateUser(collection["firstName"], collection["lastName"], collection["email"]);
            return RedirectToAction("Users", "Users");
        }

        // POST: UsersController/Edit
        [HttpPost]
        public ActionResult Edit(IFormCollection collection)
        {
            var user = new User
            {
                FirstName = collection["firstName"],
                LastName = collection["lastName"],
                Email = collection["email"]};
            _userService.EditUser(user);
            return RedirectToAction("Users", "Users");
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(string email)
        {
            _userService.DeleteUser(email);
            return RedirectToAction("Users", "Users");
        }
    }

    public class UserListModel
    {
        public List<User> UserList
        {
            get; set;
        }
    }

}
