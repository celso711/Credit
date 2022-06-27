using static Credit.Enums;

namespace Credit
{
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
}
