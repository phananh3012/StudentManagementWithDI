using System.Collections.Generic;

namespace StudentManagementWithDI
{
	public class Literature : ISubject
	{
		public int SubjectId { get; set; }
		public string SubjectName { get; set; }
		public int NumberOfPeriod { get; set; }
		public Dictionary<double, double> GradeRatio { get { return new Dictionary<double, double>() { { 0.4, 0.6 } }; } }
	}
}
