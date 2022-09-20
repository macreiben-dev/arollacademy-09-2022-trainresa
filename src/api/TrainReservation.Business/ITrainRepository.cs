namespace TrainReservation.Business
{
    public interface ITrainRepository
    {
        IEnumerable<string> Get(string trainName);
    }
}