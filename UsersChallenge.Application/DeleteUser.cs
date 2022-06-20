using MediatR;
using UsersChallenge.Domain.Exceptions;
using UsersChallenge.Domain.Ports;

namespace UsersChallenge.Application
{
    public class DeleteUser : IRequestHandler<DeleteUserRequest, int>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Find(request.Id);

            if (user == null)
                throw new DomainException($"User with id '{request.Id}' not found.");

            return await _userRepository.Delete(request.Id);
        }
    }

    public class DeleteUserRequest : IRequest<int>
    {
        public Guid Id { get; set; }

        public DeleteUserRequest(Guid id)
        {
            Id = id;
        }
    }
}