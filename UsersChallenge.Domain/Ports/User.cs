namespace UsersChallenge.Domain.Ports
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is User user && Id.Equals(user.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, BirthDate, Active);
        }
    }
}