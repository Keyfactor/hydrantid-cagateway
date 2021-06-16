namespace Keyfactor.HydrantId.Interfaces
{
    public interface IPolicyEnabled
    {
        bool? Ui { get; }
        bool? Rest { get; }
        bool? Acme { get; }
        bool? Scep { get; }
        bool? Est { get; }
    }
}