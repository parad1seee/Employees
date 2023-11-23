using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IEmployeeService
    {
        public EmployeeResponseModel GetEmployeeById(int id);

        public void SwitchEmployeesEnabled(int id, bool enabled);
    }
}
