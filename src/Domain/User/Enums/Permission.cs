using Domain.Common.Primitives;

namespace Domain.User.Enums;

public abstract class Permission : Enumeration<Permission>
{
    public static readonly Permission Read = new ReadPermission();
    public static readonly Permission Update = new UpdatePermission();
    public static readonly Permission Create = new CreatePermission();
    public static readonly Permission Delete = new DeletePermission();

    private Permission(int value, string name) : base(value, name)
    {
    }

    private sealed class ReadPermission : Permission
    {
        public ReadPermission() : base(1, "Read")
        {
        }
    }
    private sealed class UpdatePermission : Permission
    {
        public UpdatePermission() : base(2, "Update")
        {
        }
    }
    private sealed class CreatePermission : Permission
    {
        public CreatePermission() : base(3, "Create")
        {
        }
    }
    private sealed class DeletePermission : Permission
    {
        public DeletePermission() : base(4, "Delete")
        {
        }
    }
}
