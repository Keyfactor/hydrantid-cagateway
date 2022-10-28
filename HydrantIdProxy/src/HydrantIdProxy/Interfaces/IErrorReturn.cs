namespace Keyfactor.HydrantId.Interfaces
{
    public interface IErrorReturn
    {
        string Status { get; set; }
        string Error { get; set; }
    }
}