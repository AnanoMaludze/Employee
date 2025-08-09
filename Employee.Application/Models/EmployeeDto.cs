namespace Employee.Application.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<EmployeeDto> Subordinates { get; set; } = new();
    }
}
