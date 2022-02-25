using System;
using System.Collections.Generic;

namespace UsersGroupsCoreApi.Models
{
    public partial class User
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
