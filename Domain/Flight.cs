namespace Domain
{
    public class Flight
    {
        public int RemainingNumberOfSeats { get; set; }

        public Flight(int SeatCapacity)
        {
            RemainingNumberOfSeats = SeatCapacity;
        }

        public object? Book(string email, int NumberOfSeats)
        {
            if (RemainingNumberOfSeats < NumberOfSeats)
            {
                return new OverbookingError();
            }
            RemainingNumberOfSeats -= NumberOfSeats;
            return null;
        }
    }
}
