using System.Collections.Generic;

namespace StudentManagementWithDI
{
	public interface ISubject
	{
		int SubjectId { get; set; }
		string SubjectName { get; set; }
		int NumberOfPeriod { get; set; }
		Dictionary<double, double> GradeRatio { get; }

	}
}
