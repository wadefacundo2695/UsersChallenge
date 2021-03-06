using MediatR;
using UsersChallenge.Domain.Exceptions;
using UsersChallenge.Domain.Ports;

namespace UsersChallenge.Application
{
    public class CreateUser: IRequestHandler<CreateUserRequest, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.Name))
                throw new DomainException("Field name cannot be empty.");

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                BirthDate = request.BirthDate,
                Active = true
            };

            return await _userRepository.Create(user);
        }
    }

    public class CreateUserRequest: IRequest<User>
    {
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}