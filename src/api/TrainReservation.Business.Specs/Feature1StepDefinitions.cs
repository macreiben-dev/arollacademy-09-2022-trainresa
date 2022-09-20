using System;
using TechTalk.SpecFlow;

namespace TrainReservation.Business.Specs
{
    [Binding]
    public class Feature1StepDefinitions
    {
        [Given(@"(.*) train")]
        public void GivenTrain(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"coach A")]
        public void GivenCoachA(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"(.*) seats booked")]
        public void GivenSeatsBooked(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"I reserve seatnumber (.*) in coach A")]
        public void WhenIReserveSeatnumberInCoachA(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"I get booking")]
        public void ThenIGetBooking(Table table)
        {
            throw new PendingStepException();
        }
    }
}
