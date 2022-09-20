namespace TrainReservation.Business
{
    internal class Booking
    {
        private int seatCountRequested;
        private string trainName;
        private string bookingReference;

        public Booking(int seatCountRequested, string trainName, string bookingReference)
        {
            this.seatCountRequested = seatCountRequested;
            this.trainName = trainName;
            this.bookingReference = bookingReference;
        }

        internal IEnumerable<string> BookedSeats()
        {
            return new[] { "1A" };
        }
    }
}