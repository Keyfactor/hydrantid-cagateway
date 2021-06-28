namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyEnabled
    {
        bool? Ui { get;set; }
        bool? Rest { get;set; }
        bool? Acme { get;set; }
        bool? Scep { get;set; }
        bool? Est { get;set; }
    }
}