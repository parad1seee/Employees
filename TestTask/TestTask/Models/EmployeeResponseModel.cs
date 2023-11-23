namespace TestTask.Models
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? ManagerId { get; set; }

        public List<EmployeeResponseModel> Employees { get; set; } = new List<EmployeeResponseModel>();
    }
}
