﻿using Domain.Common.ValueObjects;

namespace Domain.Users.ValueObjects;

public class UserId : BaseId
{
    private UserId(Guid value) : base(value)
    {
    }

    public static UserId Create(Guid value) => new(value);
    public static new UserId NewId => new(BaseId.NewId);
}
