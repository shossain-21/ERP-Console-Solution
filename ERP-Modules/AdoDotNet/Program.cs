using AdoDotNet;

var connectionString = "Server=SANZIDA\\SQLEXPRESS; Database=CSharpPracticeDB; Trusted_Connection=True; TrustServerCertificate=True; Connection Timeout=60;";
DataUtility dataUtility = new DataUtility(connectionString);

Console.WriteLine("CHOOSE YOUR SQL OPERATION:");
Console.WriteLine("For INSERT Enter 1");
Console.WriteLine("For READ   Enter 2");
Console.WriteLine("For UPDATE Enter 3");
Console.WriteLine("For DELETE Enter 4");
Console.Write("Enter Your Choice: ");
var sqlOperation = int.Parse(Console.ReadLine());

if (sqlOperation == 1)
{
    var sql = "insert into Employee(EmployeeName, Age, BloodGroup, EmployeeAddress, ContactNo, DateOfJoining, EmployeeGrade, EmployeeType, EmployementType, DepartmentId, Salary) " +
    "Values(@employeeName, @age, @bloodGroup, @employeeAddress, @contactNo, @dateOfJoining, @employeegrade, @employeeType, @employmentType, @departmentId, @salary)";

    Console.Write("Employee Name: "); var employeeName = Console.ReadLine();
    Console.Write("Employee Age: "); var age = Convert.ToInt32(Console.ReadLine());
    Console.Write("Blood Group: "); var bloodGroup = Console.ReadLine();
    Console.Write("Address: "); var employeeAddress = Console.ReadLine();
    Console.Write("Contact No: "); var contactNo = Console.ReadLine();
    Console.Write("Date Of Joining: "); var dateOfJoining = Console.ReadLine();
    Console.Write("Employee Grade: "); var employeeGrade = Convert.ToInt32(Console.ReadLine());
    Console.Write("Employee Type: "); var employeeType = Convert.ToInt32(Console.ReadLine());
    Console.Write("Employment Type: "); var employmentType = Convert.ToInt32(Console.ReadLine());
    Console.Write("Department Id: "); var departmentId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Salary: "); var salary = Convert.ToInt32(Console.ReadLine());

    var parameters = new Dictionary<string, object>
{
    { "@employeeName", employeeName },
    { "@age", age },
    { "@bloodGroup", bloodGroup },
    { "@employeeAddress", employeeAddress },
    { "@contactNo", contactNo },
    { "@dateOfJoining", dateOfJoining },
    { "@employeegrade", employeeGrade },
    { "@employeeType", employeeType },
    { "@employmentType", employmentType },
    { "@departmentId", departmentId },
    { "@salary", salary }
};
    dataUtility.WriteData(sql, parameters);
}
else if (sqlOperation == 2)
{
    var sql = "select * from Employee";

    var data = dataUtility.ReadData(sql);
    foreach (var row in data)
    {
        foreach (var item in row)
        {
            Console.Write($"{item.Key}: {item.Value}   ");
        }
        Console.WriteLine();
    }
}
else if (sqlOperation == 3)
{
    Console.Write("Enter The Employee ID for UPDATE: ");
    var employeeId = int.Parse(Console.ReadLine());
    var sql = "SELECT * FROM Employee";

    Console.Write("Entered Employee Information: ");

    var data = dataUtility.ReadData(sql);
    for (var i = 0; i < data.Count; i++)
    {
        if ((int)data[i]["Id"] == employeeId)
        {
            foreach (var item in data[i])
            {
                Console.Write($"{item.Key}: {item.Value}   ");
            }
            Console.WriteLine(); break;
        }
        else continue;
    }
    Console.WriteLine();

    Console.WriteLine("Enter Update Information: ");

    Console.Write("Employee Name: "); var employeeName = Console.ReadLine();
    Console.Write("Employee Age: "); var age = Convert.ToInt32(Console.ReadLine());
    Console.Write("Blood Group: "); var bloodGroup = Console.ReadLine();
    Console.Write("Address: "); var employeeAddress = Console.ReadLine();
    Console.Write("Contact No: "); var contactNo = Console.ReadLine();
    Console.Write("Date Of Joining: "); var dateOfJoining = Console.ReadLine();
    Console.Write("Employee Grade: "); var employeeGrade = Convert.ToInt32(Console.ReadLine());
    Console.Write("Employee Type: "); var employeeType = Convert.ToInt32(Console.ReadLine());
    Console.Write("Employment Type: "); var employmentType = Convert.ToInt32(Console.ReadLine());
    Console.Write("Department Id: "); var departmentId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Salary: "); var salary = Convert.ToInt32(Console.ReadLine());

    sql = "UPDATE Employee SET " +
    "EmployeeName = @employeeName, " +
    "Age = @age, " +
    "BloodGroup = @bloodGroup, " +
    "EmployeeAddress = @employeeAddress, " +
    "ContactNo = @contactNo, " +
    "DateOfJoining = @dateOfJoining, " +
    "EmployeeGrade = @employeeGrade, " +
    "EmployeeType = @employeeType, " +
    "EmployementType = @employmentType, " +
    "DepartmentId = @departmentId, " +
    "Salary = @salary " +
    "WHERE Id = @employeeId";


    var parameters = new Dictionary<string, object>
{
    { "@employeeName", employeeName },
    { "@age", age },
    { "@bloodGroup", bloodGroup },
    { "@employeeAddress", employeeAddress },
    { "@contactNo", contactNo },
    { "@dateOfJoining", dateOfJoining },
    { "@employeegrade", employeeGrade },
    { "@employeeType", employeeType },
    { "@employmentType", employmentType },
    { "@departmentId", departmentId },
    { "@salary", salary },
    { "@employeeId", employeeId },
};
    dataUtility.WriteData(sql, parameters);
}
else if (sqlOperation == 4)
{
    Console.Write("Enter The Employee ID you want to DELETE: ");
    var employeeId = Console.ReadLine();

    var sql = "DELETE FROM Employee WHERE Id = @employeeId";
    var parameters = new Dictionary<string, object> { { "@employeeId", employeeId } };
    dataUtility.WriteData(sql, parameters);
}





//"Values('Hasnat Jamir', 35, 'A+', 'Khulna', '01521248154', '12/25/2024', 10, 1, 1, 1004, 15000)";

//var parameters = new Dictionary<string, object>
//{
//    { "@employeeName", employeeName },
//    { "@age", age },
//    { "@bloodGroup", bloodGroup },
//    { "@employeeAddress", employeeAddress },
//    { "@contactNo", contactNo },
//    { "@dateOfJoining", dateOfJoining },
//    { "@employeegrade", employeeGrade },
//    { "@employeeType", employeeType },
//    { "@employmentType", employmentType },
//    { "@departmentId", departmentId },
//    { "@salary", salary }
//};
//dataUtility.ExecuteSql(sql, parameters);

//Console.WriteLine();


//var data = dataUtility.GetData(sql);

//foreach (var row in data)
//{
//    foreach (var item in row)
//    {
//        Console.Write($"{item.Key}: {item.Value}   ");
//    }
//    Console.WriteLine();
//}