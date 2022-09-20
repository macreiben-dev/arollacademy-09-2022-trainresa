using NFluent;
using NSubstitute;
using System.ComponentModel;
using TrainReservation.Dal;

namespace TrainReservation.Business.Integration
{
    public class BookingTest
    {
        private string trainName;
        private string bookingReference;
        private ITrainRepository trainRepo;

        public BookingTest()
        {
            trainName = "Express2001";
            bookingReference = "someBookingReference";
            trainRepo = new DapperTrainRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LocalTrainReservation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private static Booking GetTarget(
            int seatCountRequested,
            string trainName,
            string bookingReference,
            ITrainRepository trainRepo
            )
        {
            return new Booking(seatCountRequested, trainName, bookingReference, trainRepo);
        }

        [Fact]
        [Category("Integration")]

        public void Should_return_seat_when_two_seats_available()
        {
            // ARRANGE
            var seatCountRequested = 1;

            Booking target = GetTarget(seatCountRequested, trainName, bookingReference, trainRepo);

            // ACT
            IEnumerable<string> actual = target.BookedSeats();

            // ASSERT
            Check.That(actual).HasSize(1);
            Check.That(actual.Single()).IsEqualTo("1A");
        }

    }

}