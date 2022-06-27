using static Credit.Enums;

namespace Credit
{
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
}
