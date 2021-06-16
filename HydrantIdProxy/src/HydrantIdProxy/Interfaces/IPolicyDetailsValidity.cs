namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyDetailsValidity
    {
        string Years { get; }
        string Months { get; }
        string Days { get; }
        bool? Required { get; }
        bool? Modifiable { get; }
    }
}