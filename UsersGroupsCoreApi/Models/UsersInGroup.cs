using System;
using System.Collections.Generic;

namespace UsersGroupsCoreApi.Models
{
    public partial class UsersInGroup
    {
        public int GroupId { get; set; }
        public string UserId { get; set; } = null!;
    }
}
