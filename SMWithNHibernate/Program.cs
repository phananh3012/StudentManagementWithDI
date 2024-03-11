using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SMWithNHibernate.Service;

namespace SMWithNHibernate
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var container = new WindsorContainer();
			container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>());
			container.Register(Component.For<ISubjectService>().ImplementedBy<SubjectService>());
			container.Register(Component.For<IClassroomService>().ImplementedBy<ClassroomService>());


			IStudentService studentService = container.Resolve<IStudentService>();
			ISubjectService subjectService = container.Resolve<ISubjectService>();
			IClassroomService classroomService = container.Resolve<IClassroomService>();

			container.Register(Component.For<IDisplayService>().ImplementedBy<DisplayService>().DependsOn(Dependency.OnValue("studentService", studentService)).DependsOn(Dependency.OnValue("classroomService", classroomService)).DependsOn(Dependency.OnValue("subjectService", subjectService)));

			IDisplayService displayService = container.Resolve<IDisplayService>();
			displayService.DisplayMenu();
		}
	}
}
