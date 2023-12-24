using System.Security.Cryptography;
using System.Text;
using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.Users.Enums;
using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User : AggregateRoot<UserId>
{
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
    }

    public string Email { get; private set; }
    public IList<byte> PasswordHash { get; private set; }
    public IList<byte> PasswordSalt { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public IList<Role> Roles { get; private set; } = new List<Role>();

    public static User Create(
        string email,
        string firstName,
        string lastName,
        string password,
        Guid? id = null)
    {
        using var hmac = new HMACSHA256();
        return new(
            UserId.Create(id ?? BaseId.NewId),
            email,
            firstName,
            lastName,
            hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            hmac.Key);
    }

    public bool VerifyPassword(string password)

    {
        using var hmac = new HMACSHA256([.. PasswordSalt]);
        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(PasswordHash);
    }

#pragma warning disable CS8618
    private User() { }
#pragma warning restore CS8618
}
