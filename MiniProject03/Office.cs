namespace MiniProject03
{

    class Office
    {
        public Location Location { get; set; }
        public Currency Currency;

        public Office(Location location)
        {
            Location = location;
            if (location == Location.Malmo)
            {
                Currency = Currency.Kron;
            }else if (location == Location.London)
            {
                Currency = Currency.Pound;
            }
            else
            {
                Currency = Currency.USD;
            }
        }

        public override string ToString()
        {
            return Location.ToString();
        }
    }
}