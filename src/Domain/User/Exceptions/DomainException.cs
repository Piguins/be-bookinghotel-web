using Domain.Common.Exceptions;
using Domain.Common.Shared;

namespace Domain.User.Exceptions;

public static partial class DomainException
{
    public static class User
    {
        // Common
        public static Error InvalidEmail => new("InvalidEmail", "Invalid email.");
        public static Error InvalidPassword => new("InvalidPassword", "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number and one special character.");
        public static Error InvalidUsername => new("InvalidUsername", "Username must be at least 3 characters long and contain only letters, numbers and underscores.");

        // Register
        public static Error EmailAlreadyExists => new("EmailAlreadyExists", "Email already exists.");
        public static Error UsernameAlreadyExists => new("UsernameAlreadyExists", "Username already exists.");

        // Login
        public static Error InvalidCredentials => new("InvalidCredentials", "Invalid credentials.");

        // Repository
        public static Error UserNotFound => new("UserNotFound", "User not found.");
    }
}
