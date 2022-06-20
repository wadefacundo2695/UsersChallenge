using MediatR;
using UsersChallenge.Domain.Exceptions;
using UsersChallenge.Domain.Ports;

namespace UsersChallenge.Application
{
    public class UpdateUserState : IRequestHandler<UpdateUserStateRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserState(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserStateRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Find(request.Id);

            if (user == null)
                throw new DomainException($"User with id '{request.Id}' not found.");

            user.Active = request.Active;

            return await _userRepository.Update(user);
        }
    }

    public class UpdateUserStateRequest : IRequest<User>
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }

        public UpdateUserStateRequest(Guid id, bool active)
        {
            Id = id;
            Active = active;
        }
    }
}
