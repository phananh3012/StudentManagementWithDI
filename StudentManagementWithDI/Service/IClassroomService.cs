using System.Collections.Generic;

namespace StudentManagementWithDI.Service
{
	public interface IClassroomService
	{
		List<Classroom> GetAll();
		void UpdateFinalGrade(double keys, double values, int id);
		void UpdateResult();
	}
}
