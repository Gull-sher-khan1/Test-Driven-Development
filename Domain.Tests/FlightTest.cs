using FluentAssertions;
namespace Domain.Tests
{
    public class FlightTest1
    {
        [Fact]
        public void Seats_should_be_2_when_1_seat_is_booked_in_flight_with_3_seats()
        {
            var flight = new Flight(SeatCapacity: 3);
            flight.Book("abc@abc.com", 1);
            flight.RemainingNumberOfSeats.Should().Be(2);
        }

        [Fact]
        public void Avoids_Overbooking()
        {
            var flight = new Flight(SeatCapacity: 3);
            var error = flight.Book("abc@abc.com", 4);
            error.Should().BeOfType<OverbookingError>();
        }
        [Fact]
        public void Books_Successfuly()
        {
            var flight = new Flight(SeatCapacity: 3);
            var error = flight.Book("abc@abc.com", 1);
            error.Should().BeNull();
        }

        // Parameterized Tests
        [Theory]
        [InlineData(4,3,1)]
        [InlineData(10, 6, 4)]
        [InlineData(2, 1, 1)]
        public void Booking_Reduces_Number_Of_Seats(int seats, int bookedSeats, int remainingSeats)
        {
            // Given
            var flight = new Flight(SeatCapacity: seats);
            // When
            flight.Book("abc@abc.com", bookedSeats);
            // Then
            flight.RemainingNumberOfSeats.Should().Be(remainingSeats);
        }
    }
}
