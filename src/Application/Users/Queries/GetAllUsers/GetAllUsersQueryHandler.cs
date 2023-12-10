namespace Application.Users.Queries.GetAllUsers;

internal class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper) : IQueryHandler<GetAllUsersQuery, List<UserResult>>
{
    public async Task<Result<List<UserResult>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetAllAsync();
        return users.Select(mapper.Map<UserResult>).ToList();
    }
}
