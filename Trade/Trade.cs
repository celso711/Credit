namespace Credit
{
    class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public bool GetRisk(IRisk risk)
        {
            return risk.GetRisk(this);
        }
    }
}
