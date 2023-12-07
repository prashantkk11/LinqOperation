namespace LINQExamples
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static void Main1()
        {
            AddRecs();

            var emps = from emp in lstEmp select emp;

            foreach (var item in emps)
            {
                Console.WriteLine(item.EmpNo);
            }
            var depts = from dept in lstDept select dept;

            foreach (var item in depts)
            {
                Console.WriteLine(item.DeptNo);
            }
        }

        static void Main2()
        {
            AddRecs();

            var emps = from emp in lstEmp select emp.Name;

            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var depts = from dept in lstDept select dept.DeptName;
            foreach (var item in depts)
            {
                Console.WriteLine(item);
            }
        }

        static void Main3()
        {
            AddRecs();

            var emps = from emp in lstEmp select new { emp.EmpNo, emp.Name };
            foreach (var item in emps)
            {
                Console.WriteLine(item.EmpNo);
                Console.WriteLine(item.Name);
            }

        }

        static void Main4()
        {
            AddRecs();
            var emps = from emp in lstEmp
                       where emp.Basic > 10000
                       select emp;

            foreach (var item in emps)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Basic);
            }
            Console.WriteLine();
            var emps2 = from emp in lstEmp
                        where emp.Name.StartsWith("V")
                        select emp;
            foreach(var item in emps2)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void Main5()
        {
            AddRecs();
            var emps = from emp in lstEmp
            //           orderby emp.Name descending
                       orderby emp.Name
                       select emp;

            var emps2 = from emp in lstEmp
                       orderby emp.DeptNo ascending, emp.Name descending
                       select emp;

            foreach (var item in emps2)
            {
                Console.WriteLine(item.DeptNo);
                Console.WriteLine(item.Name);
                Console.WriteLine(item);

            }

        }

        static void Main6()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       join dept in lstDept
                        on emp.DeptNo equals dept.DeptNo
                       select emp;

            Console.WriteLine();
            var emps2 = from emp in lstEmp
                        join dept in lstDept
                        on emp.DeptNo equals dept.DeptNo
                        select new { emp, dept };

            foreach (var item in emps2)
            {
                Console.WriteLine(item.emp.Name);
                Console.WriteLine(item.dept.DeptName);
            }



        }
    }
}

namespace LambdaExpressions
{
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static Employee GetEmps(Employee emp)
        {
            return emp;
        }
        static string GetEmps2(Employee emp)
        {
            return emp.Name;
        }

        static void Main1()
        {
            AddRecs();

            var emp = lstEmp.Select(GetEmps);
            //foreach (Employee e in emp)
            //{
            //    Console.WriteLine(e);
            //}
            //var emps = from emp in lstEmp select emp.Name;
            var emps2 = lstEmp.Select(GetEmps2);

            //anon method
            var emps3 = lstEmp.Select(delegate (Employee emp)
            {
                return emp.Name;
            });

            //foreach(var item in emps3)
            //{
            //    Console.WriteLine(item);
            //}

            var emps4 = lstEmp.Select(emp => emp);
            //foreach (var item in emps4)
            //{
            //    Console.WriteLine(item.EmpNo);
            //}

            var emps5 = lstEmp.Select(emp => new {emp.Name, emp.Gender});
            foreach (var item in emps5)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Gender);
            }

        }

        static void Main()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       where emp.Basic > 10000
                       select emp;
            //foreach (var item in emps)
            //{
            //    Console.WriteLine(item.Name + " " + item.Basic);
            //}

            var emps2 = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp.Name);

            //foreach (var item in emps2)
            //{
            //    Console.WriteLine(item);
            //}

            var emps3 = lstEmp.OrderBy(emp => emp.Name).ThenByDescending(emp => emp.DeptNo);
            foreach (var item in emps3)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.DeptNo);
            }
        }
    }
}