using VogCodeChallenge.BLL.Interfaces;

namespace VogCodeChallenge.BLL.Services
{
    public static class EmployeeDataServiceFactory
    {
        public static IEmployeeService GetEmployeeDataService(bool DBConnectivity)
        {
            IEmployeeService ret;
            if (DBConnectivity)
            {
                ret = new EmployeeDataBaseService();
            }
            else
            {
                ret = new EmployeeMemoryService();
            }
            return ret;
        }
    }
}
