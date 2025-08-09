namespace Employee.Domain.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Employees> Subordinates { get; set; } = new List<Employees>();
    }
}
