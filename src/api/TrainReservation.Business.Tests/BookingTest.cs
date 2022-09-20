using NFluent;

namespace TrainReservation.Business;

public class BookingTest
{
    private static Booking GetTarget(int seatCountRequested, string trainName, string bookingReference)
    {
        return new Booking(seatCountRequested, trainName, bookingReference);
    }

    [Fact]
    public void Should_return_firstAvailable_seat_on_train()
    {
        // ARRANGE
        var seatCountRequested = 1;
        var trainName = "Express2000";
        var bookingReference = "someBookingReference";
        Booking target = GetTarget(seatCountRequested, trainName, bookingReference);
        
        // ACT
        IEnumerable<string> actual = target.BookedSeats();

        // ASSERT
        Check.That(actual).HasSize(1);
        Check.That(actual.Single()).IsEqualTo("1A");
    }
}