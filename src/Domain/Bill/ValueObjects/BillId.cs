using Domain.Common.ValueObjects;

namespace Domain.Bill.ValueObjects;

public class BillId : BaseId
{
    public BillId(Guid value) : base(value)
    {
    }
}
