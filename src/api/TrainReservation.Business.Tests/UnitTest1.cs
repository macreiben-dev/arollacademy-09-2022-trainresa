using NFluent;

namespace TrainReservation.Business;

public class UnitTest1
{
    [Fact]
    public void Should_return_firstAvailable_seat_on_train()
    {
        // ARRANGE
        var seatCountRequested = 1;
        var trainName = "Express2000";
        var bookingReference = "someBookingReference";

        // ACT
        var target = new Booking(seatCountRequested, trainName, bookingReference);

        IEnumerable<string> actual = target.BookedSeats();

        // ASSERT
        Check.That(actual).HasSize(1);
        Check.That(actual.Single()).IsEqualTo("1A");

    }
}