using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentManagementWithDI.Service
{
	public class SubjectService : ISubjectService
	{
		private readonly SqlConnection _connection;
		public SubjectService(SqlConnection connection)
		{
			_connection = connection;
		}
		public string GetSubjectName(int subjectId)
		{
			string selectQuery = "SELECT SubjectName FROM Subjects WHERE SubjectId = @SubjectId";
			return _connection.QueryFirstOrDefault<string>(selectQuery, new { SubjectId = subjectId });
		}
		public Dictionary<double, double> GetGradeRatio(ISubject subject)
		{
			return subject.GradeRatio;
		}

		public ISubject GetSubjectType(string subjectName)
		{
			switch (subjectName)
			{
				case "Toan":
					return new Math();
				case "Van":
					return new Literature();
				case "Anh":
					return new English();
				default:
					return null;
			}
		}
	}
}
