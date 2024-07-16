using System;
using System.Linq;
using System.Data;





internal class Program
{

    static void Main(string[] args)
    {
        DataTable Employee = new DataTable("Employee");

        Employee.Columns.Add("ID", typeof(int));
        Employee.Columns.Add("Name", typeof(string));
        Employee.Columns.Add("Country", typeof(string));
        Employee.Columns.Add("Salary", typeof(Double));
        Employee.Columns.Add("Data", typeof(DateTime));



        Employee.Rows.Add(1, "monzer", "sudan", 4012, DateTime.Now);
        Employee.Rows.Add(2, "Ali", "OCR", 1002, DateTime.Now);
        Employee.Rows.Add(3, "Mohamed", "sudia", 3000, DateTime.Now);
        Employee.Rows.Add(4, "Ahmed", "Qatar", 9000, DateTime.Now);
        Employee.Rows.Add(5, "Adam", "Qatar", 5000, DateTime.Now);



        DataColumn[] PrimaryKeyColumn = new DataColumn[1];
        PrimaryKeyColumn[0] = Employee.Columns["ID"];
        Employee.PrimaryKey = PrimaryKeyColumn;



        Double MaxSalary = Convert.ToDouble(Employee.Compute("Max(Salary)", string.Empty));
        Double AvgSalary = Convert.ToDouble(Employee.Compute("Avg(Salary)", string.Empty));
        Double MinSalary = Convert.ToDouble(Employee.Compute("Min(Salary)", string.Empty));
        int CountEmployee = Employee.Rows.Count;



        Employee.DefaultView.Sort = "Salary ASC";
        Employee = Employee.DefaultView.ToTable();

        DataRow[] rData;
        rData = Employee.Select("Name = 'Monzer'");


        Console.WriteLine("Sorted By Salary ID ");
        foreach (DataRow row in Employee.Rows)
        {
            Console.WriteLine("ID:{0}\t Name : {1}\t Country : " +
                 "{2}\t Salary :{3}\t Data : {4}", row[0], row[1], row[2], row[3], row[4]);

        }

        Employee.DefaultView.Sort = "ID ASC";
        Employee = Employee.DefaultView.ToTable();  
        Console.WriteLine("Sorted By ID ");
        foreach (DataRow row in Employee.Rows)
        {
            Console.WriteLine("ID:{0}\t Name : {1}\t Country : " +
                "{2}\t Salary :{3}\t Data : {4}", row[0], row[1], row[2], row[3], row[4]);

        }


        DataRow[] DeleteData;
        DeleteData = Employee.Select("ID = 2");
        foreach(var dataRow in DeleteData)
        {
            dataRow.Delete();
        }
        //if you Work with DataBase
        //Employee.AcceptChanges();
        
        Console.WriteLine("After Deleted ID 2");
        foreach (DataRow row in Employee.Rows)
        {
            Console.WriteLine("ID:{0}\t Name : {1}\t Country : " +
                "{2}\t Salary :{3}\t Data : {4}", row[0], row[1], row[2], row[3], row[4]);



        }

        Console.WriteLine("MaxSalary : {0}, MinSalary : " +
            "{1} , AvgSalary : {2} " , MaxSalary,MinSalary,AvgSalary);

        Double NewMinSalary = Convert.ToDouble(Employee.Compute("Min(Salary)",
            "Name = 'Monzer'"));

        Employee.DefaultView.Sort = "ID ASC";
        Employee = Employee.DefaultView.ToTable();
        //Employee.AcceptChanges();

        Console.WriteLine("Data Filter ");
            foreach (DataRow row in rData)
            {
                Console.WriteLine("ID:{0}\t Name : {1}\t Country : " +
                   "{2}\t Salary :{3}\t Data : {4}", row[0], row[1], row[2], row[3], row[4]);
                Console.WriteLine("NewMaxSalary : {0}", NewMinSalary);
            }

            Console.WriteLine("Updating Records !");
        DataRow[] UpdateData;
        UpdateData = Employee.Select("ID = 3");
        foreach (var dataRow in UpdateData)
        {
            dataRow["Name"] = "Mohanad";
            dataRow["Salary"] = "7000";
        }

        foreach (DataRow row in Employee.Rows)
        {
            Console.WriteLine("ID:{0}\t Name : {1}\t Country : " +
                "{2}\t Salary :{3}\t Data : {4}", row[0], row[1], row[2], row[3], row[4]);

        }

        DataColumn dtColumn = new DataColumn();
        DataTable dtStudents = new DataTable();


        dtColumn.ColumnName = "ID";
        dtColumn.DataType = typeof(int);
       // dtColumn.MaxLength = 3;
        dtColumn.AutoIncrement = true;
        dtColumn.AutoIncrementSeed = 1;
        dtColumn.AutoIncrementStep = 1;
        dtColumn.Caption = "Student ID";
        dtColumn.ReadOnly = true;
        dtColumn.Unique = true;
        
        dtStudents.Columns.Add(dtColumn);


////////////////////////////////////////////////////////////////////////////////////////


        DataView EmployeeDataView = new DataView();
    

        EmployeeDataView = Employee.DefaultView;
        Console.WriteLine("Data View ");
        for (int i = 0; i < EmployeeDataView.Count; i++) 
        {
            Console.WriteLine(" {0} , {1} , {2} , {3}  ",EmployeeDataView[i][0] , 
                EmployeeDataView[i][1], EmployeeDataView[i][2], EmployeeDataView[i][3]
                );
               
        }

        EmployeeDataView.Sort = "Name ASC";
        Console.WriteLine("Sort Data View By Name");
        for (int i = 0; i < EmployeeDataView.Count; i++)
        {
            Console.WriteLine(" {0} , {1} , {2} , {3}  ", EmployeeDataView[i][0],
                EmployeeDataView[i][1], EmployeeDataView[i][2], EmployeeDataView[i][3]
                );

        }


        EmployeeDataView.RowFilter = "Name LIKE 'm%'";

        Console.WriteLine("Filter Data View ");
        for (int i = 0; i < EmployeeDataView.Count; i++)
        {
            Console.WriteLine(" {0} , {1} , {2} , {3}  ", EmployeeDataView[i][0],
                EmployeeDataView[i][1], EmployeeDataView[i][2], EmployeeDataView[i][3]
                );

        }

        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(Employee);
        dataSet.Tables.Add(dtStudents);

        Console.WriteLine("Print From DataSet ");
        foreach(DataRow row in dataSet.Tables["Employee"].Rows)
        {
            Console.WriteLine("{0} , {1}  ", row["ID"], row["Name"]);
        }

        Console.ReadKey();
        
    }
}

