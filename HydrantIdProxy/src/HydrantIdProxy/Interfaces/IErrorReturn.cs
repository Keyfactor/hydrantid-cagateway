namespace Keyfactor.HydrantId.Interfaces
{
    public interface IErrorReturn
    {
        int Status { get; set; }
        string Error { get; set; }
    }
}