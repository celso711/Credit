using System;
using System.Collections.Generic;

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
            Console.WriteLine("tradeCategories = { "+ tradeCategories[0]+", "  + tradeCategories[1]+", "+ tradeCategories[2]+", "+ tradeCategories[3] + " }");
        }
    }
}
