using Castle.MicroKernel.Registration;
using Castle.Windsor;
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

			var container = new WindsorContainer();
			container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>().DependsOn(Dependency.OnValue("connection", connection)));
			container.Register(Component.For<ISubjectService>().ImplementedBy<SubjectService>().DependsOn(Dependency.OnValue("connection", connection)));
			container.Register(Component.For<IClassroomService>().ImplementedBy<ClassroomService>().DependsOn(Dependency.OnValue("connection", connection)));

			container.Register(Component.For<ISubject>().ImplementedBy<Math>());
			container.Register(Component.For<ISubject>().ImplementedBy<Literature>());
			container.Register(Component.For<ISubject>().ImplementedBy<English>());

			IStudentService studentService = container.Resolve<IStudentService>();
			ISubjectService subjectService = container.Resolve<ISubjectService>();
			IClassroomService classroomService = container.Resolve<IClassroomService>();

			container.Register(Component.For<IDisplayService>().ImplementedBy<DisplayService>().DependsOn(Dependency.OnValue("studentService", studentService)).DependsOn(Dependency.OnValue("classroomService", classroomService)).DependsOn(Dependency.OnValue("subjectService", subjectService)));

			IDisplayService displayService = container.Resolve<IDisplayService>();
			displayService.DisplayMenu();
		}
	}
}
