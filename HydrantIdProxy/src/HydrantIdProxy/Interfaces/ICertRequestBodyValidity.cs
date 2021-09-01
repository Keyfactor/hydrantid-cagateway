namespace Keyfactor.HydrantId.Interfaces
{
    public interface ICertRequestBodyValidity
    {
        int? Years { get;set; }
        int? Months { get;set; }
        int? Days { get;set; }
    }
}