using UsersChallenge.Domain.Ports;

namespace UsersChallenge.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public async Task<User?> Find(Guid id)
        {
            return await userContext.Users.FindAsync(id);
        }

        public async Task<User> Create(User user)
        {
            userContext.Users.Add(user);
            await userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            userContext.Users.Update(user);
            await userContext.SaveChangesAsync();
            return user;
        }

        public async Task<int> Delete(Guid id)
        {
            var user = await userContext.Users.FindAsync(id);
            if (user == null) return 0;

            userContext.Users.Remove(user);
            return await userContext.SaveChangesAsync();
        }
    }
}
