namespace MiniProject03
{

    class Asset
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Office Office { get; set; }

        public Asset(string type, string brand, string model, double price, DateTime purchaseDate, Office office)
        {
            Type = type;
            Brand = brand;
            Model = model;
            Price = price;
            PurchaseDate = purchaseDate;
            Office = office;
        }

        public override string ToString()
        {
            return Type.PadRight(15) + Brand.PadRight(15) + Model.PadRight(15) +
                Office.Location.ToString().PadRight(15) + PurchaseDate.ToShortDateString().PadRight(15) +
                Price.ToString().PadRight(15) + Office.Currency.ToString().PadRight(15) +
                CurrencyConverter.ShowLocalCurrency(Office,Price).ToString().PadRight(15);
        }

        
    }
}