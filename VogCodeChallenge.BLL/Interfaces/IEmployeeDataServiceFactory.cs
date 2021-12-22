namespace VogCodeChallenge.BLL.Interfaces
{
    public interface IEmployeeDataServiceFactory
    {
        IEmployeeService GetEmployeeDataService(bool enableDBConnectivity);
    }
}
