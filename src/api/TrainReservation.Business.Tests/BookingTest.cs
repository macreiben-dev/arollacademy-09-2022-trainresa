using NFluent;
using NSubstitute;


namespace TrainReservation.Business.Tests;

public class BookingTest
{
    private string trainName;
    private string bookingReference;
    private ITrainRepository trainRepo;

    public BookingTest()
    {
        trainName = "Express2000";
        bookingReference = "someBookingReference";
        trainRepo = Substitute.For<ITrainRepository>();
    }

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
        trainRepo.Get(trainName).Returns(new[] { "1A" });
        Booking target = GetTarget(seatCountRequested, trainName, bookingReference, trainRepo);

        // ACT
        IEnumerable<string> actual = target.BookedSeats();

        // ASSERT
        Check.That(actual).HasSize(1);
        Check.That(actual.Single()).IsEqualTo("1A");
    }

    [Fact]
    public void Should_return_seat_when_two_seats_available()
    {
        // ARRANGE
        var seatCountRequested = 1;
  
        trainRepo.Get(trainName).Returns(new[] { "1A","2A" });
        Booking target = GetTarget(seatCountRequested, trainName, bookingReference, trainRepo);

        // ACT
        IEnumerable<string> actual = target.BookedSeats();

        // ASSERT
        Check.That(actual).HasSize(1);
        Check.That(actual.Single()).IsEqualTo("1A");
    }

    [Fact]

    public void Should_return_empty_when_booking_the_whole_train_with_one_coach()
    {
        // ARRANGE
        var seatCountRequested = 2;

        trainRepo.Get(trainName).Returns(new[] { "1A", "2A" });
        Booking target = GetTarget(seatCountRequested, trainName, bookingReference, trainRepo);

        // ACT
        IEnumerable<string> actual = target.BookedSeats();

        // ASSERT
        Check.That(actual).IsEmpty();
    }

}