using static Credit.Enums;

namespace Credit
{
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
}
