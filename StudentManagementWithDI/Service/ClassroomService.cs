using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StudentManagementWithDI.Service
{
	public class ClassroomService : IClassroomService
	{
		private readonly SqlConnection _connection;
		public ClassroomService(SqlConnection connection)
		{
			_connection = connection;
		}
		public List<Classroom> GetAll()
		{
			string selectQuery = "SELECT * FROM Classroom";
			return _connection.Query<Classroom>(selectQuery).ToList();
		}

		public void UpdateFinalGrade(double keys, double values, int id)
		{
			string updateQuery = $"UPDATE Classroom SET FinalGrade = FirstGrade * {keys} + SecondGrade * {values} where ClassroomId = {id}";
			_connection.Execute(updateQuery);
		}

		public void UpdateResult()
		{
			string updateQuery = "UPDATE Classroom SET Result = CASE WHEN FinalGrade > = 4 THEN 'Do' WHEN FinalGrade < 4 THEN 'Truot' ELSE null END";
			_connection.Execute(updateQuery);
		}
	}
}
