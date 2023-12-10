using Domain.Common.Shared;

namespace Domain.Common.Exceptions;

public static partial class DomainException
{
    public static class User
    {
        public static Error InValidId => new("InValidId", "User id is not valid.");
        public static Error InvalidEmail => new("InvalidEmail", "Invalid email.");
        public static Error InvalidPassword => new("InvalidPassword", "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number and one special character.");
        public static Error UserNotFound => new("UserNotFound", "User not found.");
        public static Error EmailAlreadyExists => new("EmailAlreadyExists", "Email already exists.");
        public static Error InvalidCredentials => new("InvalidCredentials", "Invalid credentials.");
        public static Error WrongPassword => new("WrongPassword", "Wrong password.");
    }
}
