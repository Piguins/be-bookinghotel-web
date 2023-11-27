using Domain.Common.ValueObjects;

namespace Domain.Host.ValueObjects;

public class HostId : BaseId
{
    public HostId(Guid value) : base(value)
    {
    }
}
