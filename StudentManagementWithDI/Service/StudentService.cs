using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StudentManagementWithDI.Service
{
	public class StudentService : IStudentService
	{
		private readonly SqlConnection _connection;
		public StudentService(SqlConnection connection)
		{
			_connection = connection;
		}
		public Student GetStudent(int id)
		{
			string selectQuery = "SELECT * FROM Students WHERE StudentId = @StudentId";
			return _connection.QueryFirstOrDefault<Student>(selectQuery, new { StudentId = id });

		}
		public List<Student> GetStudents()
		{
			string selectQuery = "SELECT * FROM Students";
			return _connection.Query<Student>(selectQuery).ToList();
		}

		public void InsertGrade(double firstGrade, double secondGrade, int id)
		{
			string updateQuery = "UPDATE Classroom SET FirstGrade = @FirstGrade, SecondGrade = @SecondGrade WHERE ClassroomId = @ClassroomId";
			_connection.Execute(updateQuery, new { FirstGrade = firstGrade, SecondGrade = secondGrade, ClassroomId = id });
		}

	}
}
