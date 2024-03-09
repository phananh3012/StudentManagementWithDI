using System.Collections.Generic;

namespace StudentManagementWithDI.Service
{
	public interface IStudentService
	{
		Student GetStudent(int id);
		List<Student> GetStudents();
		void InsertGrade(double firstGrade, double secondGrade, int id);
	}
}
