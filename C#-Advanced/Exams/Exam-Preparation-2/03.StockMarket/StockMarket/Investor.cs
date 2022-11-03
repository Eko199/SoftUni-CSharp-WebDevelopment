using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization <= 10_000 || MoneyToInvest < stock.PricePerShare) return;

            Portfolio.Add(stock);
            MoneyToInvest -= stock.PricePerShare;
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = FindStock(companyName);

            if (stock == null)
                return $"{companyName} does not exist.";

            if (sellPrice < stock.PricePerShare)
                return $"Cannot sell {companyName}.";

            Portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) 
            => Portfolio.SingleOrDefault(stock => stock.CompanyName == companyName);

        public Stock FindBiggestCompany()
            => Portfolio.OrderByDescending(stock => stock.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
            => $"The investor {FullName} with a broker {BrokerName} has stocks:\n{string.Join(Environment.NewLine, Portfolio)}";
    }
}
