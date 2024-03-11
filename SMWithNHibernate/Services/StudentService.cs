using System.Collections.Generic;
using System.Linq;

namespace SMWithNHibernate.Service
{
	public class StudentService : IStudentService
	{
		public Student GetStudent(int id)
		{
			using (var session = NHibernateSession.OpenSession())
			{
				return session.Query<Student>().Where(s => s.StudentId == id).FirstOrDefault();
			}
		}
		public List<Student> GetStudents()
		{
			using (var session = NHibernateSession.OpenSession())
			{
				return session.Query<Student>().ToList();
			}
		}



	}
}
