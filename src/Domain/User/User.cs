using System.Security.Cryptography;
using System.Text;
using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.User.Enums;
using Domain.User.ValueObjects;
using Domain.UserInfo.ValueObjects;

namespace Domain.User;

public class User : AggregateRoot<UserId>
{
    private readonly List<Role> _roles = [];

    private User(UserId id,
                 string email,
                 string firstName,
                 string lastName,
                 byte[] passwordHash,
                 byte[] passwordSalt)
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        _roles.Add(Role.Guest);
    }

    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserInfoId UserInfoId { get; private set; } = null!;
    public IReadOnlyList<Role> Roles => _roles.AsReadOnly();

    public void AddHostRole() => _roles.Add(Role.Host);

    public static User Create(
        string email,
        string firstName,
        string lastName,
        string password)
    {
        using var hmac = new HMACSHA256();
        return new(
            UserId.Create(BaseId.NewId),
            email,
            firstName,
            lastName,
            hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            hmac.Key);
    }

    public static bool VerifyPassword(
        string password,
        byte[] storedHash,
        byte[] storedSalt)
    {
        using var hmac = new HMACSHA256(storedSalt);
        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }

    public static User DefaultHost()
    {
        var user = Create(
            "host@host.host",
            "Host",
            "Host",
            "host");
        user.AddHostRole();
        return user;
    }

    // #pragma warning disable CS8618
    //     private User() { }
    // #pragma warning restore CS8618
}
