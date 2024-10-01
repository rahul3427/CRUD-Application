using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace finalCRUD.Models
{
    public class employeedb
    {
        string cs = ConfigurationManager.ConnectionStrings["dbsc"].ConnectionString;
        public List<employees> GetEmployees() { 
            SqlConnection conn = new SqlConnection(cs);
            List<employees> emp = new List<employees>();
            conn.Open();
            string query = "select * from employee";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) { 
                employees employee = new employees();
                employee.id=Convert.ToInt32(reader.GetValue(0).ToString());
                employee.name = reader.GetValue(1).ToString();
                employee.gender = reader.GetValue(2).ToString();
                employee.age= Convert.ToInt32(reader.GetValue(3).ToString());
                employee.salary= Convert.ToInt32(reader.GetValue(4).ToString());
                employee.city= reader.GetValue(5).ToString();
                emp.Add(employee);
            }
            conn.Close();
            return emp;
        
        }
        public bool addEmployee(employees emp)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "insert into employee values(@name,@gender,@age,@salary,@city)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            conn.Open();
            int i=cmd.ExecuteNonQuery();
            conn.Close();
            return i > 0;
        }
        public bool editEmployee(employees emp)
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "update employee set name=@name,gender=@gender,age=@age,salary=@salary,city=@city where id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", emp.id);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@gender", emp.gender);
            cmd.Parameters.AddWithValue("@age", emp.age);
            cmd.Parameters.AddWithValue("@salary", emp.salary);
            cmd.Parameters.AddWithValue("@city", emp.city);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i > 0;
        }
        public bool deleteEmployee(employees emp) {
            SqlConnection conn = new SqlConnection(cs);
            string query = "delete employee where id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", emp.id);
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i > 0;
        }


    }
}