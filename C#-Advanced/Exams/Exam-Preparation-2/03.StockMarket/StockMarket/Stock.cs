namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization => PricePerShare * TotalNumberOfShares;

        public override string ToString()
            => $"Company: {CompanyName}\n" +
               $"Director: {Director}\n" +
               $"Price per share: ${PricePerShare}\n" +
               $"Market capitalization: ${MarketCapitalization}";
    }
}
