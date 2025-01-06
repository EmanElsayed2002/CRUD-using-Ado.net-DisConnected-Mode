using BLL.Entity;
using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManger
{
    public class StudentManager
    {
        public static DataTable GetAll()
        {
            string Query = "SELECT * FROM STUDENT";
            DataTable dt = DBManager.ExecuteQuery(Query);
            return dt;
        }
        public static DataTable GetFullName()
        {
            string Query = "SELECT  St_Id, St_Fname + ' ' + St_Lname as Fullname  FROM STUDENT";
            DataTable dt = DBManager.ExecuteQuery(Query);
            return dt;
        }



        public static List<string> GetStudentNames()
        {
            string Query = "SELECT St_Fname + ' ' + St_Lname as FullName FROM STUDENT";
            DataTable dt = DBManager.ExecuteQuery(Query);
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(Convert.ToString(dr["FullName"]));
            }
            return list;
        }


        public static DataTable GetById(int id)
        {
            var Query = $"select * from Student where St_Id = {id}";
            DataTable dt = DBManager.ExecuteQuery(Query);
            return dt;
        }

        public static Student GetStudentByID(int id)
        {
            var Query = $"select * from Student where St_Id = {id}";
            DataTable dt = DBManager.ExecuteQuery(Query);
            Student student = new Student
            {
                St_Id = Convert.ToInt32(dt.Rows[0]["St_Id"]),
                St_Fname = Convert.ToString(dt.Rows[0]["St_Fname"]),
                St_Lname = Convert.ToString(dt.Rows[0]["St_Lname"]),
                St_Address = Convert.ToString(dt.Rows[0]["St_Address"]),
                St_Age = Convert.ToInt32(dt.Rows[0]["St_Age"]),
                //St_super = Convert.ToInt32(dt.Rows[0]["St_super"])
            };
            return student;
        }

        public static int InsertDateIntoDB(Student s)
        {
            var Query = "insert into Student(St_Id , St_Fname , St_Lname , St_Address ,St_Age) values(@Id , @Fname , @Lname , @Address , @Age)";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id", s.St_Id),
                new SqlParameter("@Fname", s.St_Fname),
                new SqlParameter("@Lname", s.St_Lname),
                new SqlParameter("@Address", s.St_Address),
                new SqlParameter("@Age", s.St_Age),
            };
            int rowsAffected = DBManager.ExecuteNonQuery(Query, sqlParameters);
            return rowsAffected;
        }

        public static int UpdateDateIntoDB(Student s)
        {
            var Query = $"update Student set St_Fname = @Fname ,St_Lname = @Lname , St_Address = @Address , St_Age = @Age where St_Id= @Id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id" , s.St_Id),
                new SqlParameter("@Fname" , s.St_Fname),
                new SqlParameter("@Lname" , s.St_Lname),
                new SqlParameter("@Age" , s.St_Age),
                new SqlParameter("@Address" , s.St_Address)
            };
            int rowsAffected = DBManager.ExecuteNonQuery(Query, sqlParameters);
            return rowsAffected;
        }

        public static int deleteDateFromDB(int id)
        {
            var Query = "DELETE FROM STUDENT WHERE St_Id = @Id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id" , id)
            };
            int rowsAffected = DBManager.ExecuteNonQuery(Query, sqlParameters);
            return rowsAffected;
        }

        public static int deleteCouseStudent(int id)
        {
            var Query = "DELETE FROM Stud_Course WHERE St_Id = @Id";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Id" , id)
            };
            int rowsAffected = DBManager.ExecuteNonQuery(Query, sqlParameters);
            return rowsAffected;
        }
        public static DataTable ShowStudentSourse(int id)
        {
            var Query = "SELECT c.Crs_Name AS CourseName, c.Crs_Duration AS Duration  FROM Stud_Course sc  INNER JOIN Course c ON sc.Crs_Id = c.Crs_Id WHERE sc.St_Id = @StudentID";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@StudentID" , id)
            };
            DataTable dt = DAL.DBManager.ExecuteQuery(Query , sqlParameters);
            return dt;
        }
    }
}
