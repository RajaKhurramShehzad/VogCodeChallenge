using VogCodeChallenge.BLL.Interfaces;

namespace VogCodeChallenge.BLL.Services
{
    public static class EmployeeServiceFactory
    {
        public static IEmployeeService GetEmployeeService(bool DBConnectivity)
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
