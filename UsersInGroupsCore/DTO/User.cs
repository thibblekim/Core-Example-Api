namespace UsersInGroupsCore.DTO
{
    public class User
    {
        public User()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
