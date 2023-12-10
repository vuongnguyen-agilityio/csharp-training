using Domain.Primitives;
using Domain.Users;

namespace Domain.Profiles
{
    public class Profile : BaseEntity
    {
        public Profile(ProfileId id, UserId userId, string firstName, string lastName, int age)
        {
            Id = id;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        private Profile() {}

        public ProfileId Id { get; private set; }
        public UserId UserId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public void Update(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
