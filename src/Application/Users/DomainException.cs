using Domain.Common.Shared;

namespace Application.Users;

internal static partial class DomainException
{
    public static class User
    {
        public static class Auth
        {
            // Common
            public static Error InvalidEmail => new("InvalidEmail", "Invalid email.");
            public static Error InvalidPassword => new("InvalidPassword", "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number and one special character.");

            // Register
            public static Error EmailAlreadyExists => new("EmailAlreadyExists", "Email already exists.");

            // Login
            public static Error InvalidCredentials => new("InvalidCredentials", "Invalid credentials.");
            public static Error WrongPassword => new("WrongPassword", "Wrong password.");

            // Repository
            public static Error UserNotFound => new("UserNotFound", "User not found.");
        }
    }
}
