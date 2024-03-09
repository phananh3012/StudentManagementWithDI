using StudentManagementWithDI.Service;
using System.Data.SqlClient;

namespace StudentManagementWithDI
{
	internal class Program
	{
		static void Main(string[] args)
		{

			string connectionString = "Server= NAMNP-2020\\SQLEXPRESS; Database= StudentManagement; Trusted_Connection= True; TrustServerCertificate= True";
			SqlConnection connection = new SqlConnection(connectionString);

			IStudentService studentService = new StudentService(connection);
			IClassroomService classroomService = new ClassroomService(connection);
			ISubjectService subjectService = new SubjectService(connection);

			DisplayService displayService = new DisplayService(studentService, classroomService, subjectService);

			displayService.DisplayMenu();
		}
	}
}
