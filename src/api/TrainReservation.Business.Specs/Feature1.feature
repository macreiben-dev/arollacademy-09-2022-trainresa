Feature: Feature1

A short summary of the feature

@tag1
Scenario: Toto
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