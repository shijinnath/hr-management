namespace EmployeeService.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Department { get; set; }
        public ReportingManager ReportingManager { get; set; }
    }
}
