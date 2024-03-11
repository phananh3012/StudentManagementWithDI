using System.Collections.Generic;

namespace SMWithNHibernate.Service
{
	public interface IStudentService
	{
		Student GetStudent(int id);
		List<Student> GetStudents();
	}
}
