namespace Credit
{
    interface IRisk
    {
        string Type { get; }

        bool GetRisk(ITrade trade);
    }
}
