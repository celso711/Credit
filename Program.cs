using System;
using System.Collections.Generic;
using static Credit.Enums;

namespace Credit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ITrade> portfolio;
            List<string> tradeCategories;

            Trade trade1 = new Trade { Value = 2000000, ClientSector = "Private" };
            Trade trade2 = new Trade { Value = 400000, ClientSector = "Public" };
            Trade trade3 = new Trade { Value = 500000, ClientSector = "Public" };
            Trade trade4 = new Trade { Value = 3000000, ClientSector = "Public" };

            portfolio = new List<ITrade> { trade1, trade2, trade3, trade4 };

            tradeCategories = new Category(portfolio).GetTradeCategories();

            foreach (ITrade trade in portfolio)
            {
                Console.WriteLine("{ Value =  " +  trade.Value + " ClientSector = " + trade.ClientSector + " }");
            }
            Console.Write("portfolio = { ");
            for (int i=1; i<= portfolio.Count; i++)
            {
                if (i == portfolio.Count)
                    Console.Write("Trade" + i);
                else
                    Console.Write("Trade" + i + ",");
            }
            Console.WriteLine(" }");
            Console.WriteLine("Output:");
            Console.WriteLine("tradeCategories = { "+ tradeCategories[0]+","  + tradeCategories[1]+","+ tradeCategories[2]+","+ tradeCategories[3] + " }");
        }
    }
    class Category
    {
        private List<ITrade> portfolio;

        public Category(List<ITrade> portfolio)
        {
            this.portfolio = portfolio;
        }

        public List<string> GetTradeCategories()
        {
            IRisk risk = null;

            List<string> tradeCategories = new List<string>();

            List<IRisk> risks = new List<IRisk> {
                RiskFactory.Create(RiskType.LowRisk),
                RiskFactory.Create(RiskType.MediumRisk),
                RiskFactory.Create(RiskType.HighRisk)
            };

            foreach (Trade trade in portfolio)
            {
                foreach (IRisk r in risks)
                {
                    risk = r;

                    if (trade.GetRisk(r))
                    {
                        break;
                    }
                }

                tradeCategories.Add(risk.Type);
            }

            return tradeCategories;
        }
    }
    interface IRisk
    {
        string Type { get; }

        bool GetRisk(ITrade trade);
    }
     class RiskFactory
    {
        public static  IRisk Create(RiskType risk)
        {
            return Create(risk.ToString());
        }

        public static IRisk Create(string risk)
        {
            switch (risk)
            {
                case "LowRisk":
                    return new LowRisk();
                case "MediumRisk":
                    return new MediumRisk();
                case "HighRisk":
                    return new HighRisk();
                default:
                    throw new NotImplementedException();
            }
        }
    }
    class LowRisk : IRisk
    {
        public string Type { get; private set; }

        public bool GetRisk(ITrade trade)
        {
            if (trade.Value < 1000000 && trade.ClientSector.Equals(RiskSector.Public.ToString()))
            {
                this.Type = RiskType.LowRisk.ToString().ToUpper();

                return true;
            }
            return false;
        }
    }
    class MediumRisk : IRisk
    {
        public string Type { get; private set; }

        public bool GetRisk(ITrade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector.Equals(RiskSector.Public.ToString()))
            {
                this.Type = RiskType.MediumRisk.ToString().ToUpper();

                return true;
            }

            return false;
        }
    }
    class HighRisk : IRisk
    {
        public string Type { get; private set; }

        public bool GetRisk(ITrade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector.Equals(RiskSector.Private.ToString()))
            {
                this.Type = RiskType.HighRisk.ToString().ToUpper();

                return true;
            }

            return false;
        }
    }
    class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public bool GetRisk(IRisk risk)
        {
            return risk.GetRisk(this);
        }
    }
    interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
    }
}
