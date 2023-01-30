using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace WojtekApp
{
    public class StudentDAO
    {
        public string connString { get; set; }

        public StudentDAO(string connectionString)
        {
            connString = connectionString;
        }

        public void create(Student student)
        {

            SqlConnection con = new SqlConnection(connString);

            String query = $"INSERT INTO StudentsData (Name, Surname, Class) VALUES ('{student.Name}', '{student.Surname}', '{student.Class}')";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        public List<Student> getAll()
        {
            List<Student> students = new();
            SqlConnection con = new SqlConnection(connString);

            String query = $"SELECT * FROM StudentsData";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dbr;
            try
            {
                con.Open();
                dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    string sID = dbr["Id"].ToString();
                    string sname = (string)dbr["Name"]; // name is string value
                    string ssurname = (string)dbr["Surname"];
                    string sclass = dbr["Class"].ToString();
                    Student student = new Student
                    {
                        Id = int.Parse(sID),
                        Name = sname,
                        Surname = ssurname,
                        Class = sclass
                    };
                    students.Add(student);
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            return students;
        }
    }
}
