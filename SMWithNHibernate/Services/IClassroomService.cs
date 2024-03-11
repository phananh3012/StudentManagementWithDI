using System.Collections.Generic;

namespace SMWithNHibernate.Service
{
	public interface IClassroomService
	{
		List<Classroom> GetAll();
		Classroom GetClassroom(int id);

		void InsertGrade(double firstGrade, double secondGrade, int id);

		void UpdateFinalGrade(double firstGrade, double firstGradeRatio, double secondGrade, double secondGradeRatio, int id);
		void UpdateResult();
	}
}
