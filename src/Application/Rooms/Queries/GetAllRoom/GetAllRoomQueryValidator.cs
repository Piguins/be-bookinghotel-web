using FluentValidation;

namespace Application.Rooms.Queries.GetAllRoom;

public class GetAllRoomQueryValidator : AbstractValidator<GetAllRoomQuery>
{
    public GetAllRoomQueryValidator()
    {
        // RuleFor(x => x.MinPrice)
        //     .GreaterThan(0);
        // RuleFor(x => x.MaxPrice)
        //     .GreaterThan(0);
    }
}
