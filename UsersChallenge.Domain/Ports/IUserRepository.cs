namespace UsersChallenge.Domain.Ports
{
    public interface IUserRepository
    {
        Task<User?> Find(Guid id);

        Task<User> Create(User user);

        Task<User> Update(User user);

        Task<int> Delete(Guid Id);
    }
}
