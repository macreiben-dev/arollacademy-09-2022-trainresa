using NFluent;
using NSubstitute;
using TrainReservation.Business;


namespace TrainReservation.Business;

public class BookingTest
{
    private static Booking GetTarget(
        int seatCountRequested,
        string trainName,
        string bookingReference,
        ITrainRepository trainRepo
    ) {
        return new Booking(seatCountRequested, trainName, bookingReference, trainRepo);
    }

    [Fact]
    public void Should_return_firstAvailable_seat_on_train()
    {
        // ARRANGE
        var seatCountRequested = 1;
        var trainName = "Express2000";
        var bookingReference = "someBookingReference";
        var trainRepo = Substitute.For<ITrainRepository>();
        trainRepo.Get(trainName).Returns(new[] { "1A" });
        Booking target = GetTarget(seatCountRequested, trainName, bookingReference, trainRepo);

        // ACT
        IEnumerable<string> actual = target.BookedSeats();

        // ASSERT
        Check.That(actual).HasSize(1);
        Check.That(actual.Single()).IsEqualTo("1A");
    }


}