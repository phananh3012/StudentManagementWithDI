using System.Collections.Generic;

namespace StudentManagementWithDI
{
	public class English : ISubject
	{
		public int SubjectId { get; set; }
		public string SubjectName { get; set; }
		public int NumberOfPeriod { get; set; }
		public Dictionary<double, double> GradeRatio { get { return new Dictionary<double, double>() { { 0.5, 0.5 } }; } }
	}
}
