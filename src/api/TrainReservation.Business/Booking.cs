namespace TrainReservation.Business
{
    public class Booking
    {
        private int seatCountRequested;
        private string trainName;
        private string bookingReference;
        private readonly ITrainRepository trainRepo;

        public Booking(int seatCountRequested, string trainName, string bookingReference, ITrainRepository trainRepo)
        {
            this.seatCountRequested = seatCountRequested;
            this.trainName = trainName;
            this.bookingReference = bookingReference;
            this.trainRepo = trainRepo;
        }

        public IEnumerable<string> BookedSeats()
        {
            IEnumerable<string> availableSeats = trainRepo.Get(trainName);

            if (seatCountRequested == 1 && availableSeats.Count() == 1)
                return new[] { availableSeats.First() };

            if (AvailableSeatsEqualRequestedSeats(availableSeats))
                return Enumerable.Empty<string>();

            return new[] { availableSeats.First() };
        }

        private bool AvailableSeatsEqualRequestedSeats(IEnumerable<string> availableSeats)
        {
            return seatCountRequested == availableSeats.Count();
        }
    }
}