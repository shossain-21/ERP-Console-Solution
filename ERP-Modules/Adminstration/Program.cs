using Adminstration;

Employee employee1 = new Employee(RandomNumberGenerator.Generator());
EmployeeType employeeType = new EmployeeType();

Console.WriteLine("Input: ");
Console.Write("Name: "); employee1.Name = Console.ReadLine();
Console.Write("Age: "); employee1.Age = int.Parse(Console.ReadLine());
Console.Write("Date of Joining: "); employee1.DateofJoining = DateTime.Parse(Console.ReadLine());
Console.Write("Contact No.: "); employee1.ContactNo = Console.ReadLine();
Console.Write("Blood Group: "); employee1.BloodGroup = Console.ReadLine();
Console.Write("Employee Type: "); employeeType.Type = Console.ReadLine();



Console.WriteLine("Output: ");

employee1.EmployeeDetails(employeeType);