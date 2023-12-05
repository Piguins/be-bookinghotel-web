﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Bookings;
using Domain.Booking;
using Domain.Booking.ValueObjects;

namespace Infrastructure.Services.Repositories;
public class BookingRepository : IBookingRepository
{
    private static readonly List<Booking> Bookings = new();
    public Task<Booking> AddAsync(Booking aggregate) => Task.Run(() =>
    {
        Bookings.Add(aggregate);
        return aggregate;
    });
    public Task DeleteAsync(BookingId id) => throw new NotImplementedException();
    public Task<IEnumerable<Booking>> GetAllAsync() => throw new NotImplementedException();
    public Task<Booking?> GetByIdAsync(BookingId id)
    {
        return Task.Run(() =>
        {
            return Bookings.FirstOrDefault(booking => booking.Id.Equals(id));
        });
    }
    public Task<Booking?> UpdateAsync(Booking aggregate)
    {
        return Task.Run(() =>
        {
            var booking = Bookings.FirstOrDefault(booking => booking.Id.Equals(aggregate.Id));
            if(booking != null)
            {
                booking.RoomTypeId = aggregate.RoomTypeId;
                booking.FromDate = aggregate.FromDate;
                booking.EndDate = aggregate.EndDate;
                booking.RoomCount = aggregate.RoomCount;
            }
            return booking;
        });
    }
}
