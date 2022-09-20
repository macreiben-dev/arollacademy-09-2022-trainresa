Feature: BookSiteOnOneTrain

As a user I book seat on a train.

@tag1
Scenario: Reserve one seat in one train with one coach with two places.
Given 1 train 
And coach A
| Seats     |
| 1         |
| 2         |
And 0 seats booked
When I reserve seatnumber 1 in coach A
Then I get booking
| Bookings               |
| Coach A - seatnumber 1 |