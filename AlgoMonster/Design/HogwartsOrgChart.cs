/*

Problem: Build and print the org chart using indentation. 

Part 1: print 
Albus Dumbledore (CEO)
    Minerva McGonagall (VP Engineering)
        Harry Potter (Senior Engineer)
            Ron Weasley (Software Engineer)
        Hermione Granger (Senior Engineer)
    Severus Snape (VP Product)
        Draco Malfoy (Product Manager)

Part 2: Then, if an employee is missing a department, inherit it from the closest manager above them.
Example output:

Albus Dumbledore (CEO, Executive)
    Minerva McGonagall (VP Engineering, Engineering)
        Harry Potter (Senior Engineer, Engineering)
            Ron Weasley (Software Engineer, Engineering)
        Hermione Granger (Senior Engineer, Engineering)
    Severus Snape (VP Product, Product)
        Draco Malfoy (Product Manager, Product)

    dictionary<emp, list<emp>>
    1 -> vp, vp 
    albus -> 

    1 -> 
    albus ->
        2 mine -> harry, herm

*/

using System.Data;

public class HogwartsOrgChart
{
    public class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public string Position { get; }
        public string Department { get; set; }
        public int? ManagerId { get; }

        public Employee(
            int id,
            string name,
            string position,
            string department,
            int? managerId)
        {
            Id = id;
            Name = name;
            Position = position;
            Department = department;
            ManagerId = managerId;
        }
    }

    
    public static List<Employee> _Employees = new();

    public static Dictionary<int, List<int>> _OrgChartMap = new();

    public static int CEO;

    public static void CreateEmployees()
    {
        _Employees = new List<Employee>
        {
            new Employee(1, "Albus Dumbledore", "CEO", "Executive", null),
            new Employee(2, "Minerva McGonagall", "VP Engineering", "Engineering", 1),
            new Employee(3, "Severus Snape", "VP Product", "Product", 1),
            new Employee(4, "Harry Potter", "Senior Engineer", null, 2),
            new Employee(5, "Hermione Granger", "Senior Engineer", "Engineering", 2),
            new Employee(6, "Draco Malfoy", "Product Manager", null, 3),
            new Employee(7, "Ron Weasley", "Software Engineer", null, 4)
        };

        // build dictionary
        foreach(var empl in _Employees)
        { 
            var managerId = empl.ManagerId;

            if(!_OrgChartMap.ContainsKey(empl.Id))
            {
                _OrgChartMap.Add(empl.Id, new List<int>()); 
            }

            if(managerId == null)
            {
                // CEO node
                CEO = empl.Id;
            }
            else   
            {
                _OrgChartMap[managerId.Value].Add(empl.Id);
            }
        }
    }

    public static void Main(string[] args)
    {
        CreateEmployees();
        PrintEmployees();
    }

    public static void PrintEmployees()
    {   
        printEmployeesDfs(CEO, _OrgChartMap[CEO], 0);
    }
    
    public static void FillMissingDepartment()
    {
        foreach(var emp in _Employees)
        {
            if(emp.Department == null && emp.ManagerId != null)
            {
                var mgr = _Employees.Where(x => x.Id == emp.ManagerId).FirstOrDefault();
                if(mgr != null)
                    emp.Department = mgr.Department;
            }
        }
    }

    private static void printEmployeesDfs(int employeeId, List<int> reportee,  int index)
    {
        var currentEmployee = _Employees.Where(x => x.Id == employeeId).SingleOrDefault();

        if(currentEmployee == null)
            return;

        for(int i = 0; i < index; i++)
        {
            Console.WriteLine(" ");
        }
        Console.WriteLine(currentEmployee.Name);

        if(reportee.Count == 0)
            return;

        // recurse
        foreach(var empl in reportee)
        {
            printEmployeesDfs(empl, _OrgChartMap[empl], index+1);
        }
    }
}
