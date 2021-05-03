using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Prueba_SP.Models;
using System.Data;

namespace Prueba_SP
{
    public class db
    {
        public SqlConnection con = new SqlConnection("Data Source=192.168.100.58,59639; Initial Catalog=Empleados;Integrated Security=True;User ID=sa;Password=Sopmass2019@");

        public void Add_record(Empleados emp) {
            SqlCommand com = new SqlCommand("SP_EMP_ADD", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@NameEmp", emp.NameEmp);
            com.Parameters.AddWithValue("@AddressEmp", emp.AddressEmp);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update_record(Empleados emp) {
            SqlCommand command = new SqlCommand("SP_EMP_UPDATE", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Emp_id", emp.EmpId);
            command.Parameters.AddWithValue("@NameEmp", emp.NameEmp);
            command.Parameters.AddWithValue("@AddressEmp", emp.AddressEmp);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        public DataSet Find_recordId(int id) {
            SqlCommand command = new SqlCommand("SP_FIND_ID", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Emp_id", id);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_Data()
        {
            SqlCommand command = new SqlCommand("SP_EMPLOYEE_ALL", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
