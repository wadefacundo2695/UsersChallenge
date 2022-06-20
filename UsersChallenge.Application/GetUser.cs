using MediatR;
using UsersChallenge.Domain.Exceptions;
using UsersChallenge.Domain.Ports;

namespace UsersChallenge.Application
{
    public class FindUser : IRequestHandler<FindUserRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public FindUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(FindUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Find(request.Id);

            if (user == null)
                throw new DomainException($"User with id '{request.Id}' not found.");

            return user;
        }
    }

    public class FindUserRequest : IRequest<User>
    {
        public Guid Id { get; set; }

        public FindUserRequest(Guid id)
        {
            Id = id;
        }
    }
}