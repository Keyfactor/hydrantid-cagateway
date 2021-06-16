namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBodyValidity
    {
        int? Years { get; }
        int? Months { get; }
        int? Days { get; }
    }
}