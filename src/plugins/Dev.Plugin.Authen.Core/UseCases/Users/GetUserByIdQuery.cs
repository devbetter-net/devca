namespace Dev.Plugin.Authen.Core.UseCases.Users;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}
