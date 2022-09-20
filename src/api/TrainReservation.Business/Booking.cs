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
            return new[] { trainRepo.Get(trainName).First() };
        }



    }
}