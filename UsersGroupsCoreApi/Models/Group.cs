using System;
using System.Collections.Generic;

namespace UsersGroupsCoreApi.Models
{
    public partial class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
    }
}
